using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceShip : Destructible
    {
        #region Properties
        public float ThrustControl
        {
            get => _thrustControl;
            set
            {
                _thrustControl = value;
                backTrail.SetActive(_thrustControl > 0.0f);
            }
        }
        public float TorqueControl
        {
            get => _torqueControl;
            set
            {
                _torqueControl = value;
                leftTrail.SetActive(_torqueControl < 0.0f);
                rightTrail.SetActive(_torqueControl > 0.0f);
            }
        }

        #endregion


        #region Editor Fields
        [Header("Space Ship")]
        [SerializeField]
        private float m_mass, m_thrust, m_mobility, m_maxLinearVelocity, m_maxAngularVelocity;


        [SerializeField] private GameObject impactEffect;

        [SerializeField] private GameObject backTrail, leftTrail, rightTrail;
        #endregion

        #region Fields
        private Rigidbody2D m_rigid;
        private float _thrustControl, _torqueControl;

        #endregion

        #region Unity Events
        protected override void Start()
        {
            base.Start();

            m_rigid = GetComponent<Rigidbody2D>();
            m_rigid.mass = m_mass;

            m_rigid.inertia = 1.0f;

            InitOffensive();
        }
        protected override void OnDeath()
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);

            base.OnDeath();

            InitOffensive();
        }
        private void FixedUpdate()
        {
            UpdateRigidbody();

            UpdateEnergyRegen();
        }
        private void UpdateRigidbody()
        {
            m_rigid.AddForce(m_thrust * ThrustControl * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);

            m_rigid.AddForce(-m_rigid.velocity * (m_thrust / m_maxLinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

            m_rigid.AddTorque(TorqueControl * m_mobility * Time.fixedDeltaTime, ForceMode2D.Force);

            m_rigid.AddTorque(-m_rigid.angularVelocity * (m_mobility / m_maxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        #endregion
        #region Turret
        [SerializeField] private Turret[] turrets;

        public void Fire(TurretMode mode)
        {
            for (int i = 0; i < turrets.Length; i++)
            {
                if (turrets[i].TurretMode == mode) turrets[i].Fire();
            }
        }
        [SerializeField] private int maxEnergy, maxAmmo, energyRegenPerSecond;

        private float primaryEnergy;

        private int secondaryAmmo;

        public void AddEnergy(float energy)
        {
            primaryEnergy += energy;
            primaryEnergy = Mathf.Clamp(primaryEnergy, 0, maxEnergy);
        }
        public void AddAmmo(int ammo)
        {
            secondaryAmmo += ammo;
            secondaryAmmo = Mathf.Clamp(secondaryAmmo, 0, maxAmmo);
        }
        private void InitOffensive()
        {
            primaryEnergy = maxEnergy;
            secondaryAmmo = maxAmmo;
        }
        private void UpdateEnergyRegen()
        {
            primaryEnergy += (float)energyRegenPerSecond * Time.fixedDeltaTime;
            primaryEnergy = Mathf.Clamp(primaryEnergy, 0, maxEnergy);
        }
        public bool DrawAmmo(int count)
        {
            if (count == 0) return true;

            if (secondaryAmmo >= count)
            {
                secondaryAmmo -= count;
                return true;
            }
            return false;
        }
        public bool DrawEnergy(int count)
        {
            if (count == 0) return true;

            if (primaryEnergy >= count)
            {
                primaryEnergy -= count;
                return true;
            }
            return false;
        }
        public void AssignWeapon(TurretProperties turretProperties)
        {
            for (int i = 0; i < turrets.Length; i++)
            {
                turrets[i].AssignLoadout(turretProperties);
            }
        }
        #endregion
    }
}

