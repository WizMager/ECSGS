using Components;
using EventComponents;
using Leopotam.Ecs;
using UIScripts;

namespace Systems
{
    public class ReloadSystem : IEcsRunSystem
    {
        private EcsFilter<TryReload, AnimatorReferenceComponent>.Exclude<Reloading> _tryReloadFilter;
        private EcsFilter<WeaponComponent, ReloadFinish> _reloadFinishFilter;

        private UI _ui;
        
        public void Run()
        {
            foreach (var i in _tryReloadFilter)
            {
                ref var animatorRef = ref _tryReloadFilter.Get2(i);
                animatorRef.animator.SetTrigger("Reload");
                ref var entity = ref _tryReloadFilter.GetEntity(i);
                entity.Get<Reloading>();
                
            }

            foreach (var i in _reloadFinishFilter)
            {
                ref var weapon = ref _reloadFinishFilter.Get1(i);
                
                var needAmmo = weapon.maxInMagazine - weapon.currentInMagazine;
                weapon.currentInMagazine = needAmmo <= weapon.totalAmmo
                    ? weapon.maxInMagazine
                    : weapon.currentInMagazine + weapon.totalAmmo;
                
                weapon.totalAmmo -= needAmmo;
                weapon.totalAmmo = weapon.totalAmmo < 0 ? 0 : weapon.totalAmmo;
                if (weapon.owner.Has<PlayerComponent>())
                {
                    _ui.gameScreen.SetAmmo(weapon.currentInMagazine, weapon.totalAmmo);
                }
                ref var entity = ref _reloadFinishFilter.GetEntity(i);
                weapon.owner.Del<Reloading>();
                entity.Del<ReloadFinish>();
            }
        }
    }
}