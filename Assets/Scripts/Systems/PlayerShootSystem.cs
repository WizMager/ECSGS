using Components;
using Components.Ignore;
using Leopotam.Ecs;

namespace Systems
{
    public class PlayerShootSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputDataComponent, HasWeapon> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var inputData = ref _filter.Get1(i);
                ref var hasWeapon = ref _filter.Get2(i);
                
                if (!inputData.shootInput) return;
                hasWeapon.weapon.Get<Shoot>();
            }
        }
    }
}