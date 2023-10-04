using GameFramework.Fsm;
using GameUtils;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class StateEnemyKnockBack : FsmState<EntityEnemy>
    {
        private GameTimer _knockBackTimer;
        protected override void OnInit(IFsm<EntityEnemy> fsm)
        {
            base.OnInit(fsm);
        }

        protected override void OnEnter(IFsm<EntityEnemy> fsm)
        {
            base.OnEnter(fsm);
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
            fsm.Owner.transform.position += dir * (fsm.Owner.EntityDataEnemy.MoveSpeed * 4f * elapseSeconds);
        }

        protected override void OnLeave(IFsm<EntityEnemy> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

        protected override void OnDestroy(IFsm<EntityEnemy> fsm)
        {
            base.OnDestroy(fsm);
        }
        
        
    }   
}