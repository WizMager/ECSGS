using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public GameObject playerPrefab;
        public float playerMoveSpeed;
        public float smoothTime;
        public Vector3 cameraOffset;
    }
}