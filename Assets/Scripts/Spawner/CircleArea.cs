using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceShooter
{
    public class CircleArea : MonoBehaviour
    {
        [SerializeField] private float radius;
        public float Radius => radius;

        public Vector2 GetRandomInsideArea()
        {
            return (Vector2)transform.position + (Vector2)UnityEngine.Random.insideUnitSphere * Radius;
        }
        private static Color gizmoColor = new Color(0, 1, 0, 0.3f);
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = gizmoColor;
            Handles.DrawSolidDisc(transform.position, transform.forward, radius);
        }
#endif
    }
}