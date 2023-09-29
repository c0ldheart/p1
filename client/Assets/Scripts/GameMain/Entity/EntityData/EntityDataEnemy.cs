using System;
using UnityEngine;

namespace p1
{
    public class EntityDataEnemy : EntityData
    {
        [SerializeField]
        private float _moveSpeed = 1;
        
        [SerializeField]
        private Animator _anim;
        public EntityDataEnemy() : base()
        {
            
        }
        
        public float MoveSpeed => _moveSpeed;

        public Animator Anim
        {
            set => _anim = value;
            get => _anim;
        }
    }
}