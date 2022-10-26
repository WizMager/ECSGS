using UnityEngine;

namespace Components
{
    public struct PlayerComponent
    {
        public Rigidbody playerRigidbody;
        public Transform playerTransform;
        public Animator playerAnimator;
        public float moveSpeed;
    }
}