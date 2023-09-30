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
        private EntityDataEnemy _entityDataEnemy = null;
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
            _entityDataEnemy = userData as EntityDataEnemy;
            transform.position = _entityDataEnemy.Position +
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
                transform.position += moveInput * (_entityDataEnemy.MoveSpeed * elapseSeconds);
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
        }
    }
}