using System;
using UnityEngine;

namespace p1
{
    public class EntityDataPlayer : EntityData
    {
        [SerializeField]
        private float _moveSpeed = 5;
        
        public EntityDataPlayer(int entityId, int typeId) : base()
        {
            
        }
        
        public float MoveSpeed
        {
            get
            {
                return _moveSpeed;
            }
        }
    }
}