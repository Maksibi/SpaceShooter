using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : Entity
    {
        #region Editor Fields
        [SerializeField] private float velocity, lifetime;
        public float Velocity => velocity;

        [SerializeField] private int damage;

        [SerializeField] private ImpactEffect impactEffect;
        #endregion

        private float timer;
        #region unity events
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > lifetime) Destroy(gameObject);


            float stepLength = Time.deltaTime * velocity;
            Vector2 step = transform.up * stepLength;

            RaycastHit2D hitRay = Physics2D.Raycast(transform.position, transform.up, stepLength);
            if (hitRay)
            {
                Destructible destructible = hitRay.collider.transform.root.GetComponent<Destructible>();

                if (destructible != null && destructible != _parent)
                {
                    destructible.ApplyDamage(damage);

                    if(_parent == Player.Instance.ActiveShip & destructible.CurrentHitpoints <= 0)
                    {
                        Player.Instance.AddScore(destructible.Score);
                        if(destructible.TeamID == 2) Player.Instance.AddKill();
                    }
                }
                OnProjectileLifeEnd(hitRay.collider, hitRay.point);
            }

            transform.position += new Vector3(step.x, step.y, 0);
        }
        #endregion
        private void OnProjectileLifeEnd(Collider2D col, Vector2 pos)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        private Destructible _parent;

        public void SetParentShooter(Destructible parent)
        {
            _parent = parent;
        }
    }
}