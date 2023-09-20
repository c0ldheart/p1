using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EntityEnemy : EntityLogic
    {
        private EntityDataEnemy _entityDataEnemy = null;
        private Entity entityTarget;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            
            EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
            entityTarget = entityComponent.GetEntity(GameConst.EntityPath[EnumEntity.Player]);
            _entityDataEnemy = userData as EntityDataEnemy;
            transform.position = _entityDataEnemy.Position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);


        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
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
                transform.position += moveInput * (_entityDataEnemy.MoveSpeed * elapseSeconds);
            }
            
        }
    } 
}