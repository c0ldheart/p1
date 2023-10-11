using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameUtils;
using UnityEngine.EventSystems;

namespace p1
{
    public class EntityPlayer : EntityLogic
    {
        private EntityDataPlayer m_EntityDataPlayer;
        
        public EntityDataPlayer EntityDataPlayer => m_EntityDataPlayer;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EntityDataPlayer = userData as EntityDataPlayer;
            if (m_EntityDataPlayer == null)
            {
                Log.Error("m_EntityDataPlayer data is invalid.");
                return;
            }

            m_EntityDataPlayer.Anim = GetComponent<Animator>();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_EntityDataPlayer.GetDamage(10);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                m_EntityDataPlayer.GetExperience(10);
            }
            MoveControl(elapseSeconds);
        }
        private void MoveControl(float elapseSeconds)
        {
            Vector3 moveInput = new Vector3(0f, 0f, 0f);
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();
            transform.position += moveInput * (m_EntityDataPlayer.MoveSpeed * elapseSeconds);
            m_EntityDataPlayer.Anim.SetBool("isMoving", moveInput != Vector3.zero);
        }
        
        public void GetDamage(float damage)
        {
            if (m_EntityDataPlayer == null)
            {
                Debug.LogError("in GetDamage : m_EntityDataPlayer is null");
                return;
            }
            
            m_EntityDataPlayer.GetDamage(damage);
            EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
            PostDamageEventArgs args = PostDamageEventArgs.Create(damage);
            eventComponent.Fire(this, args);
        }

        public void GetExp(float exp)
        {
            if (m_EntityDataPlayer == null)
            {
                Debug.LogError("in GetExp : m_EntityDataPlayer is null");
                return;
            }
            
            m_EntityDataPlayer.GetExperience(exp);
        }
    }
    
}

