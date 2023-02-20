using Unity.VisualScripting;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelBoundary : MonoBehaviour
    {
        #region Singleton
        public static LevelBoundary Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        #endregion

        [SerializeField] private float _radius;
        public float Radius => _radius;

        public enum Mode
        {
            Limit,
            Teleport
        }
        [SerializeField] private Mode _mode;
        public Mode LimitMode => _mode;
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, _radius);
        }
#endif
    }
}