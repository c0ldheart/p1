using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.ObjectPool;
using GameUtils;
using UnityEngine;
using UnityGameFramework.Runtime;
using Object = UnityEngine.Object;

namespace p1
{
    public class DamageNumberManager : GlobalSingleton<DamageNumberManager>
    {
        [SerializeField]
        private DamageNumberItem m_numberToSpawn;
        [SerializeField]
        private Transform m_numberCanvas;

        private IObjectPool<DamageNumberObject> m_damageNumbeObjectPool;
        [SerializeField]
        public List<DamageNumberItem> m_damageNumberItemList = new ();
        // Start is called before the first frame update
        void Start()
        {   
            m_damageNumbeObjectPool = GameEntry.GetComponent<ObjectPoolComponent>().CreateSingleSpawnObjectPool<DamageNumberObject>("DamageNumber", 10, 10);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public void SpawnDamageNumber(float damage, Vector3 position)
        {
            DamageNumberItem damageNumberItem = CreateDamageNumberItem(position);
            damageNumberItem.SetUp(Mathf.RoundToInt(damage));
        }
        public void UnSpawnDamageNumber(DamageNumberItem damageNumberItem)
        {
            damageNumberItem.gameObject.SetActive(false);
            m_damageNumberItemList.Remove(damageNumberItem);
            m_damageNumbeObjectPool.Unspawn(damageNumberItem);
        }
        
        private DamageNumberItem CreateDamageNumberItem(Vector3 position)
        {
            DamageNumberItem damageNumberItem = null;
            DamageNumberObject damageNumberObject = m_damageNumbeObjectPool.Spawn();
            if (damageNumberObject != null)
            {
                damageNumberItem = (DamageNumberItem)damageNumberObject.Target;
                damageNumberItem.gameObject.SetActive(true);
                damageNumberItem.transform.position = position;
                damageNumberItem.LifeTimer.Reset();
            }
            else
            {
                damageNumberItem = Instantiate(m_numberToSpawn, position, Quaternion.identity, m_numberCanvas);
                m_damageNumbeObjectPool.Register(DamageNumberObject.Create(damageNumberItem), true);
            }

            m_damageNumberItemList.Add(damageNumberItem);
            return damageNumberItem;
        }
        
    }   
    public class DamageNumberObject : ObjectBase
    {
        public static DamageNumberObject Create(object target)
        {
            DamageNumberObject damageNumberObject = ReferencePool.Acquire<DamageNumberObject>(); // 从引用池获取一个IReference对象
            damageNumberObject.Initialize(target);
            return damageNumberObject;
        }
        

        protected override void Release(bool isShutdown)
        {
            var item = (DamageNumberItem)Target;
            if (item == null)
            {
                return;
            }
            Object.Destroy(item.gameObject);
        }
    }
}

