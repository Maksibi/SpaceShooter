using UnityEngine;

namespace SpaceShooter
{
    public class AIPointControl : MonoBehaviour
    {
        [SerializeField] private float radius;
        public float Radius => radius;

        private static readonly Color gizmoColor = new Color(1, 0, 0, 0.3f);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
}