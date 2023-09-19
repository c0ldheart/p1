//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using UnityGameFramework.Runtime;

namespace p1
{
    /// <summary>
    /// this参数扩展EntityComponent方法
    /// </summary>
public static class EntityExtension
    {
        private static int s_SerialId = 0;
        
        // public static void ShowEntity<T>(this EntityComponent entityComponent, int serialId, EnumEntity enumEntity, object userData = null)
        // {
        //     entityComponent.ShowEntity(serialId, enumEntity, typeof(T), userData);
        // }
        //
        // public static void ShowEntity(this EntityComponent entityComponent, int serialId, EnumEntity enumEntity, Type logicType, object userData = null)
        // {
        //     entityComponent.ShowEntity(serialId, (int)enumEntity, logicType, userData);
        // }
        //
        // public static void ShowEntity<T>(this EntityComponent entityComponent, int serialId, int entityId, object userData = null)
        // {
        //     entityComponent.ShowEntity(serialId, entityId, typeof(T), userData);
        // }
        //
        // public static void ShowEntity(this EntityComponent entityComponent, int serialId, int entityId, Type logicType, object userData = null)
        // {
        //     entityComponent.ShowEntity(serialId, entityId, logicType, Constant.AssetPriority.DefaultAssetPriority, userData);
        // }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return ++s_SerialId;
        }

    }
}
