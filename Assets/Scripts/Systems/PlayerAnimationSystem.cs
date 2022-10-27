using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private EcsFilter<AnimatorReferenceComponent, PlayerInputDataComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var animatorComponent = ref _filter.Get1(i);
                ref var inputData = ref _filter.Get2(i);

                animatorComponent.animator.SetBool("Shoot", inputData.shootInput);
                animatorComponent.animator.SetFloat("Horizontal", inputData.moveInput.x, 0.1f, Time.deltaTime);
                animatorComponent.animator.SetFloat("Vertical", inputData.moveInput.z, 0.1f, Time.deltaTime);
            }
        }
    }
}