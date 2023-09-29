using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EntityPlayer : EntityLogic
    {
        private EntityDataPlayer _entityDataPlayer = null;
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
    } 
}

