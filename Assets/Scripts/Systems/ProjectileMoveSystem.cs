using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ProjectileMoveSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var projectileComponent = ref _filter.Get1(i);

                var position = projectileComponent.projectileGameObject.transform.position;
                position += projectileComponent.direction * projectileComponent.speed * Time.deltaTime;
                projectileComponent.projectileGameObject.transform.position = position;

                var displacementSinceLastFrame = position - projectileComponent.previousPosition;
                var hit = Physics.SphereCast(projectileComponent.previousPosition, projectileComponent.radius,
                    displacementSinceLastFrame.normalized, out var hitInfo, displacementSinceLastFrame.magnitude);
                if (hit)
                {
                    ref var entity = ref _filter.GetEntity(i);
                    ref var projectileHitInfo = ref entity.Get<ProjectileHitInfoComponent>();
                    projectileHitInfo.hitInfo = hitInfo;
                }

                projectileComponent.previousPosition = projectileComponent.projectileGameObject.transform.position;
            }
        }
    }
}