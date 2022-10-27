using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputDataComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var playerComponent = ref _filter.Get1(i);
                ref var playerInputDataComponent = ref _filter.Get2(i);
                
                var direction = (playerComponent.playerTransform.forward * playerInputDataComponent.moveInput.z +
                                 playerComponent.playerTransform.right * playerInputDataComponent.moveInput.x).normalized;
                
                playerComponent.playerRigidbody.AddForce(direction * playerComponent.moveSpeed);
            }
        }
    }
}