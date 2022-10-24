﻿using Components;
using Events;
using Leopotam.Ecs;
using Tags;
using UnityEngine;

namespace Systems
{
    public class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GroundCheckComponent, JumpComponent, JumpEvent> _jumpFilter = null;

        public void Run()
        {
            foreach (var i in _jumpFilter)
            {
                ref var entity = ref _jumpFilter.GetEntity(i);
                ref var groundCheck = ref _jumpFilter.Get2(i);
                ref var jumpComponent = ref _jumpFilter.Get3(i);
                ref var movable = ref entity.Get<MovableComponent>();
                ref var velocity = ref movable.velocity;
                Debug.Log(groundCheck.isGrounded);
                
                if (!groundCheck.isGrounded) continue;
                
                velocity.y = Mathf.Sqrt(jumpComponent.jumpForce * -2f * movable.gravity);
            }
        }
    }
}