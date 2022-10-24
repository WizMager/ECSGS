using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct MouseDirectionComponent
    {
        public Vector3 lookDirection;
        public float lookSensitivity;
    }
}