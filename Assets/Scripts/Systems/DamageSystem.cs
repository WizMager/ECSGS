using Components;
using EventComponents;
using Leopotam.Ecs;

namespace Systems
{
    public class DamageSystem : IEcsRunSystem
    {
        private EcsFilter<DamageEvent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var damageEvent = ref _filter.Get1(i);
                ref var health = ref damageEvent.Target.Get<Health>();

                health.value -= damageEvent.Damage;

                if (health.value <= 0)
                {
                    damageEvent.Target.Get<DeathEvent>();
                }
                
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}