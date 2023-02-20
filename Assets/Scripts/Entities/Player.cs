using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private int _livesAmount;
        [SerializeField] private SpaceShip _Ship;
        [SerializeField] private GameObject _PlayerShipPrefab;

        [SerializeField] private CameraController cameraController;
        [SerializeField] private InputController inputController;
        #endregion
        private void Start()
        {
            _Ship.EventOnDeath.AddListener(OnShipDeath);
        }
#region Private API
        private void OnShipDeath()
        {
            _livesAmount--;

            if (_livesAmount > 0)
            {
                Respawn();
            }
        }
        private void Respawn()
        {
            var newPlayerShip = Instantiate(_PlayerShipPrefab);

            _Ship = newPlayerShip.GetComponent<SpaceShip>();
            _Ship.EventOnDeath.AddListener(OnShipDeath);

            cameraController.SetTarget(_Ship.transform);
            inputController.SetTargetShip(_Ship);
        }
        #endregion
    }
}