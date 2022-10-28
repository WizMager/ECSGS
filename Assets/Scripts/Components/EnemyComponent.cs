using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public struct EnemyComponent
    {
        public NavMeshAgent navMeshAgent;
        public float meleeAttackDistance;
        public float triggerDistance;
        public float meleeAttackInterval;
        public int damage;
        public Transform transform;
    }
}