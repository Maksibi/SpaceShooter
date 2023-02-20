using UnityEngine;

namespace SpaceShooter
{
    public class LevelBoundaryLimiter : MonoBehaviour
    {
        void Update()
        {
            if (LevelBoundary.Instance == null) return;

            var lb = LevelBoundary.Instance;
            var r = lb.Radius;

            if(transform.position.magnitude > r)
            {
                if (lb.LimitMode == LevelBoundary.Mode.Limit)
                {
                    transform.position = transform.position.normalized * r;
                }
                else
                {
                    transform.position = -transform.position.normalized * r;
                }
            }
        }
    }
}