using TMPro;
using UnityEngine;

namespace SpaceShooter
{
    public class ScoreStats : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private int lastScore;

        private void Update()
        {
            UpdateScore();
        }
        private void UpdateScore()
        {
            if(Player.Instance != null)
            {
                int currentScore = Player.Instance.Score;

                if (currentScore != lastScore)
                {
                    lastScore = currentScore;

                    text.text = "Score: " + lastScore.ToString();
                }
            }
        }
    }
}