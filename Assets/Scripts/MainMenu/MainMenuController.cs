using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuController : MonoSingleton<MainMenuController>
    {
        [SerializeField] private GameObject episodeSelector;

        [SerializeField] private SpaceShip defaultSpaceShip;

        [SerializeField] private GameObject shipSelection;

        private void Start()
        {
            LevelSequenceController.PlayerShip = defaultSpaceShip;
        }
        public void OnButtonStartNew()
        {
            episodeSelector.SetActive(true);
            gameObject.SetActive(false);
        }
        public void OnButtonExit()
        {
            Application.Quit();
        }
        public void OnSelectShipButton()
        {
            shipSelection.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}