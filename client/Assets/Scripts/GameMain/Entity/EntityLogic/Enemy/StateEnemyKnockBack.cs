using GameFramework;
using GameFramework.Fsm;
using GameUtils;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class StateEnemyKnockBack : FsmState<EntityEnemy>, IReference
    {
        private GameTimer m_KnockBackTimer = new();
        private EntityEnemy m_Owner;
        
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
            m_Owner = fsm.Owner;
            m_Owner.CollisionEnterEvent.AddListener(CollisionAttackPlayer);
            m_KnockBackTimer.MaxTime = m_Owner.KnockBackTime;
        }

        protected override void OnUpdate(IFsm<EntityEnemy> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            
            // TODO:优化击退表现
            Vector3 dir = fsm.Owner.transform.position - fsm.Owner.EntityTarget.transform.position;
            dir.Normalize();
            fsm.Owner.transform.position += dir * (fsm.Owner.EntityDataEnemy.MoveSpeed * 5f * elapseSeconds);
            
            m_KnockBackTimer.UpdateAsFinish(elapseSeconds, () =>
            {
                m_KnockBackTimer.Reset();
                fsm.Owner.KnockBackTime = 0f;
                ChangeState<StateEnemyTrack>(fsm);
            });

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
            if (other.gameObject.CompareTag("Player") && m_Owner.AttackTimer.Time == 0)
            {
                other.gameObject.GetComponent<EntityPlayer>().GetDamage(10);
                m_Owner.IsAttacking = true;
            }

            if (other.gameObject.CompareTag("Weapon"))
            {
                Debug.Log("hit weapon");
            }
        }

        public void Clear()
        {
            m_KnockBackTimer.Clear();
            m_Owner = null;
        }
    }   
}