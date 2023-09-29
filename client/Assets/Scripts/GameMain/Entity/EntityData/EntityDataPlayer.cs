using System;
using UnityEngine;

namespace p1
{
    public class EntityDataPlayer : EntityData
    {
        [SerializeField]
        private float _moveSpeed = 5;
        private HealthPoint _curHealthPoint = new(100, 100);
        
        [SerializeField]
        private Animator _anim;

        public float MoveSpeed => _moveSpeed;

        public Animator Anim
        {
            set => _anim = value;
            get => _anim;
        }
        public HealthPoint CurHealthPoint => _curHealthPoint;
        public void GetDamage(int damage)
        {
            _curHealthPoint.Minus(damage);
            Debug.Log(_curHealthPoint.Value);
        }
    }
}