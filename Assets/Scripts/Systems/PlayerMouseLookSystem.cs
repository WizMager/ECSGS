using Components;
using Leopotam.Ecs;
using Tags;
using UnityEngine;

namespace Systems
{
    public class PlayerMouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> _playerTagFilter;
        private readonly EcsFilter<PlayerTag, ModelComponent, MouseDirectionComponent> _mouseLookFilter = null;

        private Quaternion _startTransformRotation;

        public void Init()
        {
            foreach (var i in _playerTagFilter)
            {
                ref var entity = ref _playerTagFilter.GetEntity(i);
                ref var model = ref entity.Get<ModelComponent>();

                _startTransformRotation = model.bodyTransform.rotation;
            }
        }
        
        public void Run()
        {
            foreach (var i in _mouseLookFilter)
            {
                ref var modelComponent = ref _mouseLookFilter.Get2(i);
                ref var mouseDirection = ref _mouseLookFilter.Get3(i);

                ref var lookDirection = ref mouseDirection.lookDirection;
                ref var bodyTransform = ref modelComponent.bodyTransform;
                ref var cameraTransform = ref modelComponent.cameraTransform;

                var axisX = lookDirection.x;
                var axisY = lookDirection.y;

                var rotateX = Quaternion.AngleAxis(axisX, Vector3.up * Time.deltaTime * mouseDirection.lookSensitivity);
                var rotateY = Quaternion.AngleAxis(axisY,
                    Vector3.right * Time.deltaTime * mouseDirection.lookSensitivity);
                bodyTransform.rotation = _startTransformRotation * rotateX;
                cameraTransform.rotation = bodyTransform.rotation * rotateY;
            }
        }
    }
}