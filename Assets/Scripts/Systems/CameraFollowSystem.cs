using Components;
using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent> _filter;
        private SceneData _sceneData;
        private StaticData _staticData;

        private Vector3 _currentVelocity;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var playerComponent = ref _filter.Get1(i);

                var currentPosition = _sceneData.mainCamera.transform.position;
                currentPosition = Vector3.SmoothDamp(currentPosition,
                    playerComponent.playerTransform.position + _staticData.cameraOffset, ref _currentVelocity,
                    _staticData.smoothTime);
                _sceneData.mainCamera.transform.position = currentPosition;
            }
        }
    }
}