using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct MouseDirectionComponent
    {
        [HideInInspector]public Vector3 lookDirection;
        public float lookSensitivity;
    }
}