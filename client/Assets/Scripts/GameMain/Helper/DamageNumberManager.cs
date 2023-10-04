using System;
using System.Collections;
using System.Collections.Generic;
using GameUtils;
using UnityEngine;

namespace p1
{
    public class DamageNumberManager : GlobalSingleton<DamageNumberManager>
    {
        public DamageNumber NumberToSpawn;
        public Transform NumberCanvas;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public void SpawnDamageNumber(float damage, Vector3 position)
        {
            DamageNumber damageNumber = Instantiate(NumberToSpawn, position, Quaternion.identity, NumberCanvas);
            damageNumber.SetUp(Mathf.RoundToInt(damage));
        }
    }   
}

