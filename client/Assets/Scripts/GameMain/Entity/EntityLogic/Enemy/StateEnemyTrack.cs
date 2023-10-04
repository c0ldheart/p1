using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class StateEnemyTrack : FsmState<EntityEnemy>
    {
        protected override void OnInit(IFsm<EntityEnemy> fsm)
        {
            base.OnInit(fsm);
        }

        protected override void OnEnter(IFsm<EntityEnemy> fsm)
        {
            base.OnEnter(fsm);
        }

        protected override void OnUpdate(IFsm<EntityEnemy> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            if (fsm.Owner.KnockBackTime > 0f)
            {
                ChangeState<StateEnemyKnockBack>(fsm);
            }
            MoveControl(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<EntityEnemy> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

        protected override void OnDestroy(IFsm<EntityEnemy> fsm)
        {
            base.OnDestroy(fsm);
        }
        
        private void MoveControl(IFsm<EntityEnemy> fsm, float elapseSeconds, float realElapseSeconds)
        {
            // 自动追踪目标
            Entity entityTarget = fsm.Owner.EntityTarget;
            if (entityTarget != null)
            {
                Vector3 moveInput = new Vector3(0f, 0f, 0f);
                moveInput = entityTarget.transform.position - fsm.Owner.transform.position;
                moveInput.Normalize();
                fsm.Owner.transform.position += moveInput * (fsm.Owner.EntityDataEnemy.MoveSpeed * elapseSeconds);
            }
        }
    }   
}