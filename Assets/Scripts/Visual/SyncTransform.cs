using UnityEngine;

namespace SpaceShooter
{
    public class SyncTransform : MonoBehaviour
    {
        [SerializeField] private Transform target;

        void FixedUpdate()
        {
            transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
        }
    }
}