using Components;
using Data;
using Leopotam.Ecs;
using MonoScriptComponents;
using UIScripts;
using UnityEngine;
using Views;

namespace Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private SceneData _sceneData;
        private StaticData _staticData;
        private UI _ui;
        
        public void Init()
        {
            var playerEntity = _world.NewEntity();

            ref var playerComponent = ref playerEntity.Get<PlayerComponent>();
            ref var playerInputDataComponent = ref playerEntity.Get<PlayerInputDataComponent>();
            ref var hasWeapon = ref playerEntity.Get<HasWeapon>();
            ref var animator = ref playerEntity.Get<AnimatorReferenceComponent>();

            var playerGameObject = Object.Instantiate(_staticData.playerPrefab, _sceneData.playerSpawnPoint.position,
                Quaternion.identity);
            playerGameObject.GetComponent<PlayerView>().Entity = playerEntity;
            playerComponent.playerRigidbody = playerGameObject.GetComponent<Rigidbody>();
            playerComponent.playerTransform = playerGameObject.GetComponent<Transform>();
            animator.animator = playerGameObject.GetComponent<Animator>();
            playerComponent.moveSpeed = _staticData.playerMoveSpeed;

            var weaponEntity = _world.NewEntity();
            hasWeapon.weapon = weaponEntity;
            var weaponView = playerGameObject.GetComponentInChildren<WeaponSettings>();
            ref var weapon = ref weaponEntity.Get<WeaponComponent>();
            weapon.owner = playerEntity;
            weapon.projectilePrefab = weaponView.projectilePrefab;
            weapon.projectileRadius = weaponView.projectileRadius;
            weapon.projectileRoot = weaponView.projectileRoot;
            weapon.projectileSpeed = weaponView.projectileSpeed;
            weapon.totalAmmo = weaponView.totalAmmo;
            weapon.weaponDamage = weaponView.weaponDamage;
            weapon.currentInMagazine = weaponView.currentInMagazine;
            weapon.maxInMagazine = weaponView.maxInMagazine;
            _ui.gameScreen.SetAmmo(weapon.currentInMagazine, weapon.totalAmmo);
        }
    }
}