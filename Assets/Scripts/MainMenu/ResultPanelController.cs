using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class ResultPanelController : MonoSingleton<ResultPanelController>
    {
        [SerializeField] private TextMeshProUGUI kills, score, time, result, nextButtonText;

        private bool IsSuccess;
 
        public void ShowResult(PlayerStatistics levelResults, bool success)
        {
            gameObject.SetActive(true);
            IsSuccess = success;

            result.text = success ? "Win" : "Lose";
            nextButtonText.text = success ? "Next" : "Restart";
            kills.text = "Kills: " + levelResults.numKills.ToString();
            score.text = "Score: " + levelResults.score.ToString();
            time.text = "Time: " + levelResults.time.ToString();


            Time.timeScale = 0.0f;
        }
        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1.0f;
           
            if (IsSuccess) LevelSequenceController.Instance.AdvanceLevel();

            else  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}