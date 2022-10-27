using Components;
using Components.Ignore;
using Leopotam.Ecs;

namespace Systems
{
    public class ReloadSystem : IEcsRunSystem
    {
        private EcsFilter<TryReload, AnimatorReferenceComponent> _tryReloadFilter;
        private EcsFilter<WeaponComponent, ReloadFinish> _reloadFinishFilter;
        
        public void Run()
        {
            foreach (var i in _tryReloadFilter)
            {
                ref var animatorRef = ref _tryReloadFilter.Get2(i);
                animatorRef.animator.SetTrigger("Reload");
                ref var entity = ref _tryReloadFilter.GetEntity(i);
                entity.Del<TryReload>();
            }

            foreach (var i in _reloadFinishFilter)
            {
                ref var weapon = ref _reloadFinishFilter.Get1(i);

                var needAmmo = weapon.maxInMagazine - weapon.currentInMagazine;
                weapon.currentInMagazine = needAmmo >= weapon.totalAmmo
                    ? weapon.maxInMagazine
                    : weapon.currentInMagazine + weapon.totalAmmo;
                weapon.totalAmmo -= needAmmo;
                weapon.totalAmmo = weapon.totalAmmo < 0 ? 0 : weapon.totalAmmo;
                ref var entity = ref _reloadFinishFilter.GetEntity(i);
                entity.Del<ReloadFinish>();
            }
        }
    }
}