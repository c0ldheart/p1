using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EntityDataFireBall : EntityData
    {
        
        [SerializeField]
        private float _rotateSpeed = 180;
        private Entity _entityOwner;
        private float _rotateRadius = 1.5f;
        [SerializeField]
        public EntityDataFireBall(Vector3 pos) : base()
        {   
            m_Position = pos;
        }
        public float RotateSpeed => _rotateSpeed;
        public float RotateRadius => _rotateRadius;
    }
}