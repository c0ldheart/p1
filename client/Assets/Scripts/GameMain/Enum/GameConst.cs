using System.Collections.Generic;

namespace p1
{
    public class GameConst
    {
        public static Dictionary<EnumEntity, string> EntityPath = new Dictionary<EnumEntity, string>()
        {
            {EnumEntity.Player, "Assets/Prefabs/Entities/Players/EntityPlayer.prefab"},
            {EnumEntity.Enemy1, "Assets/Prefabs/Entities/Enemies/EntityEnemy.prefab"},
            {EnumEntity.Camera, "Assets/Prefabs/Entities/Camera/EntityCamera.prefab"},
        };
        
        public static Dictionary<EnumEntityGroup, string> EntityGroup = new Dictionary<EnumEntityGroup, string>()
        {
            {EnumEntityGroup.Player, "PlayerGroup"},
            {EnumEntityGroup.Enemy, "EnemyGroup"},
            {EnumEntityGroup.Camera, "CameraGroup"},
        };
    }
}