using Components;
using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private SceneData _sceneData;
        private StaticData _staticData;
        
        public void Init()
        {
            var playerEntity = _world.NewEntity();

            ref var playerComponent = ref playerEntity.Get<PlayerComponent>();
            ref var playerInputDataComponent = ref playerEntity.Get<PlayerInputDataComponent>();

            var playerGameObject = Object.Instantiate(_staticData.playerPrefab, _sceneData.playerSpawnPoint.position,
                Quaternion.identity);
            playerComponent.playerRigidbody = playerGameObject.GetComponent<Rigidbody>();
            playerComponent.playerTransform = playerGameObject.GetComponent<Transform>();
            playerComponent.moveSpeed = _staticData.playerMoveSpeed;
        }
    }
}