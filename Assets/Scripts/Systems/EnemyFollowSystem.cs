using Components;
using Data;
using EventComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class EnemyFollowSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyComponent, FollowComponent> _followFilter;
        private RuntimeData _runtimeData;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var i in _followFilter)
            {
                ref var enemy = ref _followFilter.Get1(i);
                ref var follow = ref _followFilter.Get2(i);

                if (!follow.targetEntity.IsAlive())
                {
                    ref var followEntity = ref _followFilter.GetEntity(i);
                    followEntity.Del<FollowComponent>();
                    continue;
                }

                ref var targetTransformReference = ref follow.targetEntity.Get<TransformReferenceComponent>();
                var targetPosition = targetTransformReference.Transform.position;
                enemy.navMeshAgent.SetDestination(targetPosition);
                var direction = (targetPosition - enemy.transform.position).normalized;
                direction.y = 0;
                enemy.transform.forward = direction;

                if ((enemy.transform.position - targetTransformReference.Transform.position).sqrMagnitude <
                    enemy.meleeAttackDistance * enemy.meleeAttackDistance && Time.time >= follow.nextAttackTime)
                {
                    follow.nextAttackTime = Time.time + enemy.meleeAttackInterval;
                    ref var damageEvent = ref _world.NewEntity().Get<DamageEvent>();
                    damageEvent.Target = follow.targetEntity;
                    damageEvent.Damage = enemy.damage;
                }
            }
        }
    }
}