using UnityEngine;

namespace SpaceShooter
{
    public class Turret : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private TurretMode _turretMode;
        public TurretMode TurretMode => _turretMode;

        [SerializeField] private TurretProperties TurretProperties;
        #endregion
        private float _refireTimer;

        public bool CanFire => _refireTimer <= 0;

        private SpaceShip spaceShip;

        #region UnityEvents
        private void Start()
        {
            spaceShip = transform.root.GetComponent<SpaceShip>();
        }
        private void Update()
        {
            if (_refireTimer > 0) _refireTimer -= Time.deltaTime;
        }
        public void Fire()
        {
            if(TurretProperties == null) return;

            if (_refireTimer > 0 | CanFire == false) return;

            if (spaceShip.DrawEnergy(TurretProperties.EnergyUsage) == false) return;
            if (spaceShip.DrawAmmo(TurretProperties.AmmoUsage) == false) return;


            Projectile projectile = Instantiate(TurretProperties.ProjectilePrefab, transform.position, transform.rotation).GetComponent<Projectile>();
            projectile.SetParentShooter(spaceShip);

            _refireTimer = TurretProperties.Firerate;

            AudioSource.PlayClipAtPoint(TurretProperties.LaunchSFX, transform.position);
        }
        public void AssignLoadout(TurretProperties props)
        {
            if (_turretMode != props.TurretMode) return;

            _refireTimer = 0;
            TurretProperties = props;
        }
        #endregion
    }
}
