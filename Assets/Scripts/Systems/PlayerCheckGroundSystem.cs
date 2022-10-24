using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerCheckGroundSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GroundCheckComponent> _groundCheckFilter = null;

        public void Run()
        {
            foreach (var i in _groundCheckFilter)
            {
                ref var groundCheck = ref _groundCheckFilter.Get1(i);

                groundCheck.isGrounded =
                    Physics.CheckSphere(groundCheck.groundCheckPosition.position, groundCheck.checkDistance, groundCheck.groundMask);
            }
        }
    }
}