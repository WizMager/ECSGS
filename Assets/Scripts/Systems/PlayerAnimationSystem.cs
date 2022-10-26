using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputDataComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var playerComponent = ref _filter.Get1(i);
                ref var inputData = ref _filter.Get2(i);

                
                playerComponent.playerAnimator.SetFloat("Horizontal", inputData.moveInput.x, 0.1f, Time.deltaTime);
                playerComponent.playerAnimator.SetFloat("Vertical", inputData.moveInput.z, 0.1f, Time.deltaTime);
            }
        }
    }
}