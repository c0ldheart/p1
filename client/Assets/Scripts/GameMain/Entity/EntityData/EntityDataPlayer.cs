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

        public FloatNumeric Exp { get; private set; } = new FloatNumeric();
        public FloatNumeric PickUpRange { get; private set; } = new FloatNumeric();
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

        public void GetExperience(float exp)
        {
            var floatModifier = new FloatModifier
            {
                Value = exp
            };
            Exp.AddModifier(ModifierType.Add, floatModifier);
            Debug.Log("Now Experience : " + Exp.Value);
        }
    }
}