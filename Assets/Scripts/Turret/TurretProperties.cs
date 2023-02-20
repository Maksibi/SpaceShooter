using UnityEngine;

namespace SpaceShooter
{
    public enum TurretMode
    {
        Primary,
        Secondary
    }
    [CreateAssetMenu]
    public sealed class TurretProperties : ScriptableObject
    {
        [SerializeField] private TurretMode _turretMode;
        public TurretMode TurretMode => _turretMode;

        [SerializeField] private Projectile _projectilePrefab;
        public Projectile ProjectilePrefab => _projectilePrefab;

        [SerializeField] private float _firerate;
        public float Firerate => _firerate;

        [SerializeField] private int _energyUsage;
        public int EnergyUsage => _energyUsage;

        [SerializeField] private int _ammoUsage;
        public int AmmoUsage => _ammoUsage;

        [SerializeField] private AudioClip _launchSFX;
        public AudioClip LaunchSFX => _launchSFX;
    }
}