using System;
using GameFramework;
using GameFramework.Event;
using GameFramework.Procedure;
using GameUtils;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace p1
{
    public class ProcedureMain : ProcedureBase
    {
        private GameObject Health;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureMain OnEnter");

            EntityDataPlayer entityDataPlayer = new EntityDataPlayer();
            entityDataPlayer.PickUpRange.SetBase(5f);
            EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();

            entityComponent.ShowEntity<EntityPlayer>(1, GameConst.EntityPath[EnumEntity.Player], "PlayerGroup",
                userData: entityDataPlayer);
            // 开局给个火球
            var fireballId = IdGenerator.Instance.GetNextID();
            entityComponent.ShowEntity<EntityFireBall>(fireballId, GameConst.EntityPath[EnumEntity.FireBall],
                "WeaponGroup", userData: new EntityDataFireBall(entityDataPlayer.Position, 1));

            UIComponent uiComponent = GameEntry.GetComponent<UIComponent>();
            uiComponent.OpenUIForm(GameConst.UIPath[EnumUI.PlayerInfo], GameConst.UIGroup[EnumUIGroup.PlayerInfo]);

            EnemySpawner.Instance.Init();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            EnemySpawner.Instance.UpdateSpawner(elapseSeconds);
        }
    }
}