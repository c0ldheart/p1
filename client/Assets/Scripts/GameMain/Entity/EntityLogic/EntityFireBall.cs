using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EntityFireBall : EntityLogic
    {
        private EntityDataFireBall _entityDataFireBall = null;
        private Entity _entityOwner;
        private Vector3 _dir;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            _entityDataFireBall = userData as EntityDataFireBall;
            if (_entityDataFireBall == null)
            {
                Log.Error("Entity data is invalid.");
                return;
            }

            _dir = Vector3.right * _entityDataFireBall.RotateRadius;
            GameEntry.GetComponent<EntityComponent>().AttachEntity(this.Entity.Id, _entityDataFireBall.OwnerId);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
            _entityOwner = entityComponent.GetParentEntity(this.Entity.Id);
            transform.position = _entityDataFireBall.Position + Vector3.left * 1.6f;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            ;

            base.OnUpdate(elapseSeconds, realElapseSeconds);
            if (_entityOwner != null)
            {
                RotateAround(elapseSeconds);
            }
        }

        private void RotateAround(float delta)
        {
            //坐标计算  (当前坐标 + 方向向量归一化 * 固定距离)
            transform.position = _entityOwner.transform.position + _dir.normalized * _entityDataFireBall.RotateRadius;

            //绕目标物体旋转
            transform.RotateAround(_entityOwner.transform.position, Vector3.forward,
                _entityDataFireBall.RotateSpeed * delta);

            //每帧更新方向向量
            _dir = transform.position - _entityOwner.transform.position;
        }
    }
}