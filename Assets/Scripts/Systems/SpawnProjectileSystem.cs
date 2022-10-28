using Components;
using EventComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class SpawnProjectileSystem : IEcsRunSystem
    {
        private EcsFilter<WeaponComponent, SpawnProjectile> _filter;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var weapon = ref _filter.Get1(i);

                var projectileGameObject = Object.Instantiate(weapon.projectilePrefab, weapon.projectileRoot.position,
                    Quaternion.identity);
                var projectileEntity = _world.NewEntity();

                ref var projectile = ref projectileEntity.Get<ProjectileComponent>();
                
                projectile.damage = weapon.weaponDamage;
                projectile.direction = weapon.projectileRoot.forward;
                projectile.radius = weapon.projectileRadius;
                projectile.speed = weapon.projectileSpeed;
                projectile.previousPosition = projectileGameObject.transform.position;
                projectile.projectileGameObject = projectileGameObject;

                ref var entity = ref _filter.GetEntity(i);
                entity.Del<SpawnProjectile>();
            }
        }
    }
}