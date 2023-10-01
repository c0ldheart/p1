using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using Random = UnityEngine.Random;
using GameUtils;

namespace p1
{
    public class EntityEnemy : EntityLogic
    {
        public EntityDataEnemy EntityDataEnemy{ get; private set; }
        private Entity entityTarget;
        private GameTimer _attackTimer = new GameTimer(5, false);

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
            entityTarget = entityComponent.GetEntity(GameConst.EntityPath[EnumEntity.Player]);
            EntityDataEnemy = userData as EntityDataEnemy;
            transform.position = EntityDataEnemy.Position +
                                 new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            CheckDistanceAndDestroy();
            
            _attackTimer.UpdateAsFinish(elapseSeconds, () =>
            {
                _attackTimer.Reset();
                _attackTimer.CanRun = false;
            });
            MoveControl(elapseSeconds);
        }

        private void MoveControl(float elapseSeconds)
        {
            // 自动追踪目标
            if (entityTarget != null)
            {
                Vector3 moveInput = new Vector3(0f, 0f, 0f);
                moveInput = entityTarget.transform.position - transform.position;
                moveInput.Normalize();
                transform.position += moveInput * (EntityDataEnemy.MoveSpeed * elapseSeconds);
            }
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
            if (other.gameObject.CompareTag("Player") && _attackTimer.Time == 0)
            {
                other.gameObject.GetComponent<EntityPlayer>().GetDamage(10);
                _attackTimer.CanRun = true;
            }

            if (other.gameObject.CompareTag("Weapon"))
            {
                Debug.Log("hit weapon");
            }
        }
        
        public void GetDamage(int damage)
        {
            if (EntityDataEnemy == null)
            {
                Debug.LogError("in GetDamage : EntityDataEnemy is null");
                return;
            }
            EntityDataEnemy.GetDamage(damage);
            if (EntityDataEnemy.HealthPoint.Value <= 0)
            {
                GameEntry.GetComponent<EntityComponent>().HideEntity(this.Entity.Id);
            }
            // EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
            // PostDamageEventArgs args = new PostDamageEventArgs(damage);
            // eventComponent.Fire(this, args);
        }
    }
}