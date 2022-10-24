using Components;
using Leopotam.Ecs;
using Tags;
using UnityEngine;

namespace Systems
{
    sealed class PlayerMoveInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, MoveDirectionComponent> _moveDirectionFilter = null;

        private float _moveX;
        private float _moveY;

        public void Run()
        {
            SetDirection();
            
            foreach (var i in _moveDirectionFilter)
            {
                ref var directionComponent = ref _moveDirectionFilter.Get2(i);
                ref var direction = ref directionComponent.direction;

                direction.x = _moveX;
                direction.y = _moveY;
            }
        }

        private void SetDirection()
        {
            _moveX = Input.GetAxis("Horizontal");
            _moveY = Input.GetAxis("Vertical");
        }
    }
}