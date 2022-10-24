using Components;
using Events;
using Leopotam.Ecs;
using Tags;
using UnityEngine;

namespace Systems
{
    public class PlayerJumpSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, JumpComponent> _jumpEventFilter = null;

        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            
            foreach (var i in _jumpEventFilter)
            {
                ref var jumpEvent = ref _jumpEventFilter.GetEntity(i);
                jumpEvent.Get<JumpEvent>();
                Debug.Log("send jump");
            }
        }
    }
}