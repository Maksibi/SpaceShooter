using UnityEngine;

namespace SpaceShooter
{
    public class CollisionDamageApplicator : MonoBehaviour
    {
        public static string IgnoreTag = "WorldBoundary";

        [SerializeField] private float DamageMultiplier, DamageConstant;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == IgnoreTag) return;

            var desctructible = transform.root.GetComponent<Destructible>();

            if (desctructible != null)
            {
                desctructible.ApplyDamage((int)DamageConstant + (int)(DamageMultiplier * collision.relativeVelocity.magnitude));
            }
        }
    }
}