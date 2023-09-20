using System;
using UnityEngine;

namespace p1
{
    public class EntityDataPlayer : EntityData
    {
        [SerializeField]
        private float _moveSpeed = 5;
        
        [SerializeField]
        private Animator _anim;
        public EntityDataPlayer() : base()
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