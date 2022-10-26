using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputDataComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var inputDataComponent = ref _filter.Get1(i);

                inputDataComponent.moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            }
        }
    }
}