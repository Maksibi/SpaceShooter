using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoSingleton<Player>
    {
        #region Editor Fields
        [SerializeField] private int _livesAmount;
        [SerializeField] private SpaceShip ship;
        public SpaceShip ActiveShip => ship;
        [SerializeField] private GameObject _PlayerShipPrefab;

        [SerializeField] private CameraController cameraController;
        [SerializeField] private InputController inputController;
        #endregion
        private void Start()
        {
            Respawn();
        }
        protected override void Awake()
        {
            base.Awake();

            if (ship != null) Destroy(ship.gameObject);
        }
        #region Private API
        private void OnShipDeath()
        {
            _livesAmount--;

            if (_livesAmount > 0)
            {
                Respawn();
            }
            else LevelSequenceController.Instance.FinishCurrentLevel(false);
        }
        private void Respawn()
        {
            if(LevelSequenceController.PlayerShip != null)
            {
                var newPlayerShip = Instantiate(LevelSequenceController.PlayerShip);

                ship = newPlayerShip.GetComponent<SpaceShip>();
                ship.EventOnDeath.AddListener(OnShipDeath);

                cameraController.SetTarget(ship.transform);
                inputController.SetTargetShip(ship);
            }
        }
        #endregion

        #region Score
        public int Score { get; private set; }
        public int NumKills { get; private set; }

        public void AddKill()
        {
            NumKills++;
        }
        public void AddScore(int num)
        {
            Score += num;
            Debug.Log(Score);
            Debug.Log(num);
        }

        #endregion
    }
}