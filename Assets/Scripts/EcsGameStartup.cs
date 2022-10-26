using System;
using Data;
using Leopotam.Ecs;
using Systems;
using UnityEngine;

public class EcsGameStartup : MonoBehaviour
{
       [SerializeField] private SceneData sceneData;
       [SerializeField] private StaticData staticData;
       private EcsWorld _world;
       private EcsSystems _updateSystems;
       private EcsSystems _fixedUpdateSystems;

       private void Start()
       {
              _world = new EcsWorld();
              _updateSystems = new EcsSystems(_world);
              _fixedUpdateSystems = new EcsSystems(_world);
              var runtimeData = new RuntimeData();

              _updateSystems
                     .Add(new PlayerInitSystem())
                     .Add(new PlayerInputSystem())
                     .Add(new PlayerRotationSystem())
                     .Add(new PlayerAnimationSystem())
                     .Inject(sceneData)
                     .Inject(staticData)
                     .Inject(runtimeData);

              _fixedUpdateSystems
                     .Add(new PlayerMoveSystem());
              
              _updateSystems.Init();
              _fixedUpdateSystems.Init();
       }

       private void Update()
       {
              _updateSystems?.Run();
       }

       private void FixedUpdate()
       {
              _fixedUpdateSystems.Run();
       }

       private void OnDestroy()
       {
              _updateSystems?.Destroy();
              _updateSystems = null;
              
              _fixedUpdateSystems?.Destroy();
              _fixedUpdateSystems = null;
              
              _world.Destroy();
              _world = null;
       }
}