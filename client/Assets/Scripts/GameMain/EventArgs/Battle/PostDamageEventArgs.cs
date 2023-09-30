using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace p1
{
    public class PostDamageEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PostDamageEventArgs).GetHashCode();
        public EntityLogic Attacker { get; private set; }
        
        public int Damage { get; private set; }

        public PostDamageEventArgs(int damage)
        {
            Damage = damage;
        }
        public override void Clear()
        {
            Damage = 0;
        }

        public override int Id => EventId;
    }
}
