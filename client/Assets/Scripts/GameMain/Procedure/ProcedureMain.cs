using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace p1
{
    public class ProcedureMain : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureMain OnEnter");

            EntityDataPlayer entityDataPlayer = new EntityDataPlayer();
            EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
            
            entityComponent.ShowEntity<EntityPlayer>(1, GameConst.EntityPath[EnumEntity.Player], "PlayerGroup", userData:new EntityDataPlayer());
            entityComponent.ShowEntity<EntityEnemy>(2, GameConst.EntityPath[EnumEntity.Enemy1], "EnemyGroup", userData:new EntityDataEnemy());
            entityComponent.ShowEntity<EntityCamera>(3, GameConst.EntityPath[EnumEntity.Camera], "CameraGroup");
        }
    
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }
    }
}