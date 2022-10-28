using Components;
using EventComponents;
using Leopotam.Ecs;
using UnityEngine;
using Views;

namespace Systems
{
    public class EnemyInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        
        public void Init()
        {
            foreach (var enemyView in Object.FindObjectsOfType<EnemyView>())
            {
                var enemyEntity = _world.NewEntity();

                ref var enemy = ref enemyEntity.Get<EnemyComponent>();
                ref var health = ref enemyEntity.Get<Health>();

                health.value = enemyView.startHealth;
                enemy.damage = enemyView.damage;
                enemy.triggerDistance = enemyView.triggerDistance;
                enemy.meleeAttackDistance = enemyView.meleeAttackDistance;
                enemy.meleeAttackInterval = enemyView.meleeAttackInterval;
                enemy.navMeshAgent = enemyView.navMeshAgent;
                enemy.transform = enemyView.transform;

                enemyEntity.Get<EnemyIdle>();
                enemyView.entity = enemyEntity;
            }
        }
    }
}