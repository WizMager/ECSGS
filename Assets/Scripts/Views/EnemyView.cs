using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Views
{
    public class EnemyView : MonoBehaviour
    {
        public EcsEntity entity;
        public NavMeshAgent navMeshAgent;
        public float meleeAttackDistance;
        public float triggerDistance;
        public float meleeAttackInterval;
        public int startHealth;
        public int damage;
    }
}