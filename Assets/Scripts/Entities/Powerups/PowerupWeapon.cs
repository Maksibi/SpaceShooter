using SpaceShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PowerupWeapon : Powerup
    {
        [SerializeField] private TurretProperties turretProperties;

        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AssignWeapon(turretProperties);
        }
    }
}