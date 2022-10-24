using Components;
using Leopotam.Ecs;
using Tags;
using UnityEngine;

namespace Systems
{
    public class PlayerMouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, MouseDirectionComponent> _mouseDirectionFilter = null;

        private float _axisX;
        private float _axisY;
        
        public void Run()
        {
            GetAxis();

            foreach (var i in _mouseDirectionFilter)
            {
                ref var mouseDirectionComponent = ref _mouseDirectionFilter.Get2(i);

                ref var lookDirection = ref mouseDirectionComponent.lookDirection;
                lookDirection.x += _axisX;
                lookDirection.y = ClampAxis(_axisY, lookDirection.y);
            }
        }

        private void GetAxis()
        {
            _axisX = Input.GetAxis("Mouse X");
            _axisY = Input.GetAxis("Mouse Y");
        }
        
        private float ClampAxis(float axisY, float previousAxisYDirection)
        {
            return Mathf.Clamp(previousAxisYDirection - axisY, -60, 60);
        }
    }
}