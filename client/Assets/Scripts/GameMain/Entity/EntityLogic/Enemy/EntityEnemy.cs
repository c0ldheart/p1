using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;
using Random = UnityEngine.Random;
using GameUtils;
using UnityEngine.Events;

namespace p1
{
    public class EntityEnemy : EntityLogic
    {
        public EntityDataEnemy EntityDataEnemy{ get; private set; }
        private Entity entityTarget;
        private GameTimer _attackTimer = new GameTimer(5, false);
        private IFsm<EntityEnemy> _fsm;
        private static int SERIAL_ID = 0;
        public Entity EntityTarget => entityTarget;
        public float KnockBackTime = 0f;
        public UnityEvent<Collision2D> CollisionEnterEvent = new();

        public GameTimer AttackTimer
        {
            get => _attackTimer;
            set => _attackTimer = value;
        }
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            // 不要在这里写逻辑，对象池复用不再调用OnInit
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
            entityTarget = entityComponent.GetEntity(GameConst.EntityPath[EnumEntity.Player]);
            EntityDataEnemy = userData as EntityDataEnemy;
            transform.position = EntityDataEnemy.Position +
                                 new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            
            //  TODO：使得Entity在对象池复用FSM。
            List<FsmState<EntityEnemy>> stateList = new List<FsmState<EntityEnemy>>()
            {
                // GF引用池式实例化状态类
                StateEnemyTrack.Create(), 
                StateEnemyKnockBack.Create(),
            };
            _fsm = GameEntry.GetComponent<FsmComponent>().CreateFsm((SERIAL_ID++).ToString(), this, stateList);
            _fsm.Start<StateEnemyTrack>();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            CheckDistanceAndDestroy();
            
            _attackTimer.UpdateAsFinish(elapseSeconds, () =>
            {
                _attackTimer.Reset();
                _attackTimer.CanRun = false;
            });
            // MoveControl(elapseSeconds);
        }



        private void CheckDistanceAndDestroy()
        {
            if (Vector3.Distance(transform.position, entityTarget.transform.position) >
                EnemySpawner.Instance.MaxDistance)
            {
                GameEntry.GetComponent<EntityComponent>().HideEntity(this.Entity.Id);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionEnterEvent.Invoke(other);
        }
        
        public void GetDamage(float damage)
        {
            if (EntityDataEnemy == null)
            {
                Debug.LogError("in GetDamage : EntityDataEnemy is null");
                return;
            }
            EntityDataEnemy.GetDamage(damage);
            if (EntityDataEnemy.HealthPoint.Value <= 0)
            {
                GameEntry.GetComponent<EntityComponent>().HideEntity(Entity.Id);
            }
            // EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
            // PostDamageEventArgs args = new PostDamageEventArgs(damage);
            // eventComponent.Fire(this, args);
        }
        
        public void GetDamage(float damage, float knockBackTime)
        {
            GetDamage(damage);
            KnockBackTime = knockBackTime;
            DamageNumberManager.Instance.SpawnDamageNumber(damage, transform.position);
        }
        
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            GameEntry.GetComponent<FsmComponent>().DestroyFsm(_fsm);
            foreach (var state in _fsm.GetAllStates())
            {
                ReferencePool.Release((IReference)state);
            }
        }
    }
    
}