using UnityEngine;

namespace SpaceShooter
{
    public static class Utils
    {
        public static Vector3 MakeLead(Projectile projectile, Transform targetTransform, Transform currentPosition, Rigidbody2D targetRB)
        {
            float timeToTarget = (targetTransform.transform.position - currentPosition.position).magnitude / projectile.Velocity;

            return targetTransform.position + (Vector3)targetRB.velocity * timeToTarget;
        }
    }
}
