using UnityEngine;
using UnityGameFramework.Runtime;

namespace p1
{
    public class EntityCamera : MonoBehaviour
    {
        private Transform _playTransform;
        protected void Start()
        {   
            
        }
        
        private void LateUpdate()
        {
            if (!_playTransform)
            {
                EntityComponent entityComponent = GameEntry.GetComponent<EntityComponent>();
                Entity entityPlayer = entityComponent.GetEntity(1);
                if (entityPlayer)
                    _playTransform = entityPlayer.transform;
            }
            else
            {
                var position = _playTransform.position;
                transform.position = new Vector3(position.x, position.y,
                    -10);
            }
        }
    }
}