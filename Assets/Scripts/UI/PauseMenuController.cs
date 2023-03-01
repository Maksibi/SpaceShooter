using UnityEngine;
using UnityEngine.SceneManagement;
namespace SpaceShooter
{
    public class PauseMenuController : MonoSingleton<PauseMenuController>
    {
        public bool isPaused = false;
        private void Start()
        {
            gameObject.SetActive(false);
            isPaused = false;
        }
        public void OnButtonShowPause()
        {
            Time.timeScale = 0.0f;

            gameObject.SetActive(true);

            isPaused = true;
        }
        public void OnButtonContinue()
        {
            Time.timeScale = 1.0f;

            gameObject.SetActive(false);

            isPaused=false;
        }
        public void OnButtonMainMenu()
        {
            Time.timeScale = 1.0f;

            isPaused = false;

            gameObject.SetActive(false);

            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneNickname); 
        }
    }
}