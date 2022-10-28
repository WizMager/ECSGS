using Components;
using EventComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class EnemyDeathSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent, DeathEvent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var enemy = ref _filter.Get1(i);
                Object.Destroy(enemy.transform.gameObject);

                _filter.GetEntity(i).Destroy();
            }
        }
    }
}