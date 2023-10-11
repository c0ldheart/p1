using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EntityExperience : EntityLogic
    {
        private EntityDataExperience m_EntityDataExperience = null;
        private Entity m_EntityOwner;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_EntityDataExperience = userData as EntityDataExperience;
            transform.position = m_EntityDataExperience.Position;

        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            // var entityPlayer = GameEntry.GetComponent<EntityComponent>().GetEntity((int)EnumEntity.Player)?.Logic as EntityPlayer;;
            // if (entityPlayer != null)
            // {
            //     var distance = Vector3.Distance(entityPlayer.transform.position, transform.position);
            //     if (distance < entityPlayer.EntityDataPlayer.PickUpRange.Value)
            //     {
            //         entityPlayer.GetExp(m_EntityDataExperience.Exp);
            //         GameEntry.GetComponent<EntityComponent>().HideEntity(Entity.Id);
            //     }
            // }
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("Player"))
            {
                EntityPlayer entityPlayer = other.GetComponent<EntityPlayer>();
                entityPlayer.GetExp(m_EntityDataExperience.Exp);
                GameEntry.GetComponent<EntityComponent>().HideEntity(Entity.Id);
            }
        }
    }
}