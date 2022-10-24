using System;
using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using Systems;
using UnityEngine;
using Voody.UniLeo;

public class EscGameStarter : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();

        AddInjections();
        AddOneFrame();
        AddSystems();
        
        _systems.Init();
    }

    private void AddInjections()
    {
        
    }

    private void AddOneFrame()
    {
        
    }

    private void AddSystems()
    {
        _systems
            .Add(new PlayerMoveInputSystem())
            .Add(new PlayerMouseInputSystem())
            .Add(new MovementSystem())
            .Add(new PlayerMouseLookSystem());
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        if (_systems == null) return;
        
        _systems.Destroy();
        _systems = null;
        
        _world.Destroy();
        _world = null;
    }
}
