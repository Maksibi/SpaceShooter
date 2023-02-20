using UnityEngine;

namespace SpaceShooter
{
    public class PowerupStats : Powerup
    {
        public enum EffectType
        {
            AddAmmo,
            AddEnergy
        }
        [SerializeField] private EffectType effectType;

        [SerializeField] private float effectValue;

        protected override void OnPickedUp(SpaceShip ship)
        {
            if (effectType == EffectType.AddEnergy) ship.AddEnergy(effectValue);
            if (effectType == EffectType.AddAmmo) ship.AddAmmo((int) effectValue);
        }
    }
}