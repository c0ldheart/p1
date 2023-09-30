using System;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace p1
{
    public class UIPlayerInfo : UIFormLogic
    {
        private Slider m_Slider;
        private Text m_Text;
        private EntityPlayer m_EntityPlayer;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_Slider = transform.Find("Health/Slider").GetComponent<Slider>();
            m_Text = transform.Find("Health/HealthText").GetComponent<Text>();
            m_EntityPlayer = GameEntry.GetComponent<EntityComponent>().GetEntity(1).Logic as EntityPlayer;
            
            GameEntry.GetComponent<EventComponent>().Subscribe(PostDamageEventArgs.EventId, UpdateHealthBar);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            UpdateHealthBar();
        }

        private void UpdateHealthBar(object send = null, EventArgs e = null)
        {
            m_Slider.value = m_EntityPlayer.EntityDataPlayer.HealthPoint.Value / (float)m_EntityPlayer.EntityDataPlayer.HealthPoint.MaxValue;
            m_Text.text = m_EntityPlayer.EntityDataPlayer.HealthPoint.Value + "/" + m_EntityPlayer.EntityDataPlayer.HealthPoint.MaxValue;
        }

    }
}