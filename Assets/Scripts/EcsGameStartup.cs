using Data;
using EventComponents;
using Leopotam.Ecs;
using Systems;
using UIScripts;
using UnityEngine;

public class EcsGameStartup : MonoBehaviour
{
       [SerializeField] private SceneData sceneData;
       [SerializeField] private StaticData staticData;
       [SerializeField] private UI ui;
       
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
                     .OneFrame<TryReload>()
                     .Add(new PlayerInputSystem())
                     .Add(new PlayerRotationSystem())
                     .Add(new PlayerAnimationSystem())
                     .Add(new CameraFollowSystem())
                     .Add(new WeaponShootSystem())
                     .Add(new SpawnProjectileSystem())
                     .Add(new ProjectileMoveSystem())
                     .Add(new ProjectileHitSystem())
                     .Add(new ReloadSystem())
                     .Add(new PauseSystem())
                     .Inject(sceneData)
                     .Inject(staticData)
                     .Inject(ui)
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