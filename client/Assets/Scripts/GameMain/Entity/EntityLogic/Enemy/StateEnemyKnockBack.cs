using GameFramework;
using GameFramework.Fsm;
using GameUtils;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class StateEnemyKnockBack : FsmState<EntityEnemy>, IReference
    {
        private GameTimer _knockBackTimer;
        private EntityEnemy _owner;
        
        public static StateEnemyKnockBack Create()
        {
            StateEnemyKnockBack state = ReferencePool.Acquire<StateEnemyKnockBack>();
            return state;
        }
        protected override void OnInit(IFsm<EntityEnemy> fsm)
        {
            base.OnInit(fsm);
        }

        protected override void OnEnter(IFsm<EntityEnemy> fsm)
        {
            base.OnEnter(fsm);
            _owner = fsm.Owner;
            _owner.CollisionEnterEvent.AddListener(CollisionAttackPlayer);
            _knockBackTimer = new GameTimer(fsm.Owner.KnockBackTime);
        }

        protected override void OnUpdate(IFsm<EntityEnemy> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            
            _knockBackTimer.UpdateAsFinish(elapseSeconds, () =>
            {
                _knockBackTimer.Reset();
                _knockBackTimer.CanRun = false;
                fsm.Owner.KnockBackTime = 0f;
                ChangeState<StateEnemyTrack>(fsm);
            });
            // TODO:优化击退表现
            Vector3 dir = fsm.Owner.transform.position - fsm.Owner.EntityTarget.transform.position;
            dir.Normalize();
            fsm.Owner.transform.position += dir * (fsm.Owner.EntityDataEnemy.MoveSpeed * 5f * elapseSeconds);
        }

        protected override void OnLeave(IFsm<EntityEnemy> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
            fsm.Owner.CollisionEnterEvent.RemoveListener(CollisionAttackPlayer);

        }

        protected override void OnDestroy(IFsm<EntityEnemy> fsm)
        {
            base.OnDestroy(fsm);
        }
        
        private void CollisionAttackPlayer(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && _owner.AttackTimer.Time == 0)
            {
                other.gameObject.GetComponent<EntityPlayer>().GetDamage(10);
                _owner.AttackTimer.CanRun = true;
            }

            if (other.gameObject.CompareTag("Weapon"))
            {
                Debug.Log("hit weapon");
            }
        }

        public void Clear()
        {
            _knockBackTimer.Reset();
            _owner = null;
        }
    }   
}