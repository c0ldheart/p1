using System;
using UnityEngine;

namespace p1
{
    public class EntityDataEnemy : EntityData
    {
        
        [SerializeField]
        private float _moveSpeed = 1;
        private HealthPoint _healthPoint = new(100, 100);
        [SerializeField]
        private Animator _anim;
        public EntityDataEnemy(Vector3 pos) : base()
        {   
            m_Position = pos;
        }
        
        public float MoveSpeed => _moveSpeed;
        public HealthPoint HealthPoint => _healthPoint;
        public Animator Anim
        {
            set => _anim = value;
            get => _anim;
        }
        public void GetDamage(int damage)
        {
            _healthPoint.Minus(damage);
        }
    }
}