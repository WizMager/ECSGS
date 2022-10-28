using Components;
using EventComponents;
using Leopotam.Ecs;
using Views;

namespace Systems
{
    public class ProjectileHitSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent, ProjectileHitInfoComponent> _filter;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var projectile = ref _filter.Get1(i);
                ref var projectileHit = ref _filter.Get2(i);

                if (projectileHit.hitInfo.collider.gameObject.TryGetComponent(out EnemyView enemyView))
                {
                    if (enemyView.entity.IsAlive())
                    {
                        ref var damageEvent = ref _world.NewEntity().Get<DamageEvent>();
                        damageEvent.Target = enemyView.entity;
                        damageEvent.Damage = projectile.damage;
                    }
                }
                
                
                projectile.projectileGameObject.SetActive(false);
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}