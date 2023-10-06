using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.ObjectPool;
using GameUtils;
using TMPro;
using UnityEngine;

namespace p1
{
    public class DamageNumberItem : MonoBehaviour
    {
        public TMP_Text DamagerNumberText;
        public float LifeTime = 0.5f;
        public float FloatSpeed = 0.5f;
        public GameTimer LifeTimer ;
        void Start()
        {
            LifeTimer = ReferencePool.Acquire<GameTimer>();
            LifeTimer.MaxTime = LifeTime;
        }

        void Update()
        {
            LifeTimer.UpdateAsFinish(Time.deltaTime, () =>
            {
                DamageNumberManager.Instance.UnSpawnDamageNumber(this);
            });
            transform.position += Vector3.up * FloatSpeed * Time.deltaTime;
        }

        public void SetUp(int damageDisplay)
        {
            DamagerNumberText.text = damageDisplay.ToString();
        }
    }
    

}

