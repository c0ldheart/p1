using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EntityDataExperience : EntityData
    {
        
        [SerializeField]
        private float m_MoveSpeed = 2;
        private int _ownerId;
        [SerializeField]
        public EntityDataExperience(Vector3 pos) : base()
        {   
            m_Position = pos;
        }
        public EntityDataExperience(Vector3 pos, int ownerId) : base()
        {   
            m_Position = pos;
            _ownerId = ownerId;
        }
        public float MoveSpeed => m_MoveSpeed;
        public int OwnerId => _ownerId;
        public float Exp { get; set; } = 1;
    }
}