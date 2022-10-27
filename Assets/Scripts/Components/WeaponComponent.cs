using Leopotam.Ecs;
using UnityEngine;

namespace Components
{
    public struct WeaponComponent
    {
        public EcsEntity owner;
        public GameObject projectilePrefab;
        public Transform projectileRoot;
        public float projectileSpeed;
        public float projectileRadius;
        public int weaponDamage;
        public int currentInMagazine;
        public int maxInMagazine;
        public int totalAmmo;
    }
}