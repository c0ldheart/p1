//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using GameFramework;
using UnityEngine;

namespace p1
{
    [Serializable]
    public class EntityData : IReference
    {
        private int _entityId = 0;
        private int _typeId = 0;
        protected Vector3 m_Position = Vector3.zero;

        protected Quaternion m_Rotation = Quaternion.identity;

        public EntityData()
        {
            
            m_Position = Vector3.zero;
            m_Rotation = Quaternion.identity;
            UserData = null;
        }

        public int EntityId
        {
            get => _entityId;
            set => _entityId = value;
        }
        
        public int TypeId
        {
            get => _typeId;
            set => _typeId = value;
        }
        /// <summary>
        /// 实体位置。
        /// </summary>
        public Vector3 Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                m_Position = value;
            }
        }

        /// <summary>
        /// 实体朝向。
        /// </summary>
        public Quaternion Rotation
        {
            get
            {
                return m_Rotation;
            }
            set
            {
                m_Rotation = value;
            }
        }

        public object UserData
        {
            get;
            protected set;
        }

        // public static EntityData Create(object userData = null)
        // {
        //     EntityData entityData = ReferencePool.Acquire<EntityData>();
        //     entityData.Position = Vector3.zero;
        //     entityData.Rotation = Quaternion.identity;
        //     entityData.UserData = userData;
        //     return entityData;
        // }
        //
        // public static EntityData Create(Vector3 position, object userData = null)
        // {
        //     EntityData entityData = ReferencePool.Acquire<EntityData>();
        //     entityData.Position = position;
        //     entityData.Rotation = Quaternion.identity;
        //     entityData.UserData = userData;
        //     return entityData;
        // }
        //
        // public static EntityData Create(Vector3 position, Quaternion quaternion, object userData = null)
        // {
        //     EntityData entityData = ReferencePool.Acquire<EntityData>();
        //     entityData.Position = position;
        //     entityData.Rotation = quaternion;
        //     entityData.UserData = userData;
        //     return entityData;
        // }

        public virtual void Clear()
        {
            m_Position = Vector3.zero;
            m_Rotation = Quaternion.identity;
            UserData = null;
        }
    }
}