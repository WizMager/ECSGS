using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    sealed class CursorLockSystem : IEcsInitSystem
    {
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}