using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct MoveDirectionComponent
    {
        [HideInInspector]public Vector3 direction;
    }
}