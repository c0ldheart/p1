using System.Collections.Generic;
using System.Reflection.Emit;

namespace p1
{
    public class GameConst
    {
        public static Dictionary<EnumEntity, string> EntityPath = new Dictionary<EnumEntity, string>()
        {
            {EnumEntity.Player, "Assets/Prefabs/Entities/Players/EntityPlayer.prefab"},
            {EnumEntity.Enemy1, "Assets/Prefabs/Entities/Enemies/EntityEnemy.prefab"},
            {EnumEntity.Camera, "Assets/Prefabs/Entities/Camera/EntityCamera.prefab"},
            {EnumEntity.FireBall, "Assets/Prefabs/Entities/Weapons/EntityFireBall.prefab"},
            {EnumEntity.Experience, "Assets/Prefabs/Entities/Experience/EntityExperience.prefab"},
        };
        
        public static Dictionary<EnumEntityGroup, string> EntityGroup = new Dictionary<EnumEntityGroup, string>()
        {
            {EnumEntityGroup.Player, "PlayerGroup"},
            {EnumEntityGroup.Enemy, "EnemyGroup"},
            {EnumEntityGroup.Camera, "CameraGroup"},
            {EnumEntityGroup.Weapon, "WeaponGroup"},
            {EnumEntityGroup.Experience, "ExperienceGroup"},
        };

        public static Dictionary<EnumUI, string> UIPath = new Dictionary<EnumUI, string>()
        {
            { EnumUI.PlayerInfo, "Assets/Prefabs/UI/Battle/UIPlayerInfo.prefab"},
        };
        
        public static Dictionary<EnumUIGroup, string> UIGroup = new Dictionary<EnumUIGroup, string>()
        {
            { EnumUIGroup.PlayerInfo, "PlayerInfoGroup"},
        };
    }
}