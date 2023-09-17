using System;
using UnityEngine;

namespace p1
{
    public class PlayerData : EntityData
    {
        [SerializeField]
        private float _moveSpeed = 5;
        
        public PlayerData(int entityId, int typeId) : base(entityId, typeId)
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