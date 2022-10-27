using UnityEngine;

namespace Components
{
    public struct ProjectileComponent
    {
        public int damage;
        public Vector3 direction;
        public float radius;
        public float speed;
        public Vector3 previousPosition;
        public GameObject projectileGameObject;
    }
}