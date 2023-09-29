using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EntityCamera : EntityLogic
    {
        private Transform _playTransform;
        protected void Start()
        {
          
        }
        
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            if (!_playTransform)
            {
                EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
                Entity entityPlayer = entityComponent.GetEntity(1);
                if (entityPlayer != null)
                    _playTransform = entityPlayer.transform;
            }
            var position = _playTransform.position;
            transform.position = new Vector3(position.x, position.y,
                -10);
        }
    }
}