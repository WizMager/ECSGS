using Components;
using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private EcsFilter<PlayerComponent> _filter;
        private RuntimeData _runtimeData;

        public void Run()
        {
            foreach (var i in _filter)
            {
                if (_runtimeData.IsPaused) return;
                
                ref var playerComponent = ref _filter.Get1(i);

                var plane = new Plane(Vector3.up, playerComponent.playerTransform.position);
                var ray = _sceneData.mainCamera.ScreenPointToRay(Input.mousePosition);
                if (!plane.Raycast(ray, out var distance)) continue;

                playerComponent.playerTransform.forward =
                    ray.GetPoint(distance) - playerComponent.playerTransform.position;
            }
        }
    }
}