using System;
using UnityEngine;

namespace p1
{
    public class EntityDataPlayer : EntityData
    {
        [SerializeField]
        private float _moveSpeed = 5;
        private HealthPoint _healthPoint = new(100, 100);
        
        [SerializeField]
        private Animator _anim;

        public float MoveSpeed => _moveSpeed;

        public Animator Anim
        {
            set => _anim = value;
            get => _anim;
        }
        public HealthPoint HealthPoint => _healthPoint;
        public void GetDamage(float damage)
        {
            _healthPoint.Minus(Mathf.RoundToInt(damage));
        }
    }
}