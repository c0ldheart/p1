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
        private EntityDataPlayer _entityDataPlayer;
        
        public EntityDataPlayer EntityDataPlayer => _entityDataPlayer;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            _entityDataPlayer = userData as EntityDataPlayer;
            if (_entityDataPlayer == null)
            {
                Log.Error("_entityDataPlayer data is invalid.");
                return;
            }

            _entityDataPlayer.Anim = GetComponent<Animator>();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _entityDataPlayer.GetDamage(10);
            }
            MoveControl(elapseSeconds);
        }
        private void MoveControl(float elapseSeconds)
        {
            Vector3 moveInput = new Vector3(0f, 0f, 0f);
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();
            transform.position += moveInput * (_entityDataPlayer.MoveSpeed * elapseSeconds);
            _entityDataPlayer.Anim.SetBool("isMoving", moveInput != Vector3.zero);
        }
        
        public void GetDamage(float damage)
        {
            if (_entityDataPlayer == null)
            {
                Debug.LogError("in GetDamage : _entityDataPlayer is null");
                return;
            }
            
            _entityDataPlayer.GetDamage(damage);
            EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
            PostDamageEventArgs args = new PostDamageEventArgs(damage);
            eventComponent.Fire(this, args);
        }
        
    }
    
}

