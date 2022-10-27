using Components;
using Components.Ignore;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputDataComponent, HasWeapon> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var inputDataComponent = ref _filter.Get1(i);
                ref var hasWeapon = ref _filter.Get2(i);

                inputDataComponent.moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
                inputDataComponent.shootInput = Input.GetMouseButton(0);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    ref var weapon = ref hasWeapon.weapon.Get<WeaponComponent>();

                    if (weapon.currentInMagazine < weapon.maxInMagazine)
                    {
                        ref var entity = ref _filter.GetEntity(i);
                        entity.Get<TryReload>();
                    }
                }
            }
        }
    }
}