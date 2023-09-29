using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace p1
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            string welcomeMessage = Utility.Text.Format("Hello! This is an empty project based on Game Framework {0}.", Version.GameFrameworkVersion);
            Log.Info(welcomeMessage);
            Log.Warning(welcomeMessage);
            Log.Error(welcomeMessage);
            
        }
    
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        
            ChangeState(procedureOwner, typeof(ProcedureMain));
        }
    } 
}


