using Components;
using Data;
using EventComponents;
using Leopotam.Ecs;

namespace Systems
{
    public class EnemyIdleSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent, EnemyIdle> _calmEnemyFilter;
        private RuntimeData _runtimeData;
        
        public void Run()
        {
            foreach (var i in _calmEnemyFilter)
            {
                ref var enemy = ref _calmEnemyFilter.Get1(i);
                ref var player = ref _runtimeData.PlayerEntity.Get<PlayerComponent>();

                if ((enemy.transform.position - player.playerTransform.position).sqrMagnitude <=
                    enemy.triggerDistance * enemy.triggerDistance)
                {
                    var entity = _calmEnemyFilter.GetEntity(i);
                    entity.Del<EnemyIdle>();

                    ref var follow = ref entity.Get<FollowComponent>();
                    follow.targetEntity = _runtimeData.PlayerEntity;
                }
            }
        }
    }
}