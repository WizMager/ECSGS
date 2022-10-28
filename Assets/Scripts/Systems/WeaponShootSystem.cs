using Components;
using EventComponents;
using Leopotam.Ecs;
using UIScripts;

namespace Systems
{
    public class WeaponShootSystem : IEcsRunSystem
    {
        private EcsFilter<WeaponComponent, Shoot> _filter;
        private UI _ui;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var weapon = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);
                entity.Del<Shoot>();

                if (weapon.currentInMagazine > 0)
                {
                    weapon.currentInMagazine--;
                    if (weapon.owner.Has<PlayerComponent>())
                    {
                        _ui.gameScreen.SetAmmo(weapon.currentInMagazine, weapon.totalAmmo);
                    }
                    ref var spawnProjectile = ref entity.Get<SpawnProjectile>();
                }
                else
                {
                    ref var reload = ref entity.Get<TryReload>();
                }
            }
        }
    }
}