using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct GroundCheckComponent
    {
        public bool isGrounded;
        public Transform groundCheckPosition;
        public float checkDistance;
        public LayerMask groundMask;
    }
}