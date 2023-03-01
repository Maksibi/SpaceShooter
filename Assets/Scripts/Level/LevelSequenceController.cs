using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class LevelSequenceController : MonoSingleton<LevelSequenceController>
    {
        #region Fields
        public static string MainMenuSceneNickname = "main_menu";

        public Episode CurrentEpisode { get; private set; }

        public int CurrentLevel { get; private set; }

        public bool LastLevelResult {get; private set;}

        public PlayerStatistics playerStatistics { get; private set; }

        public static SpaceShip PlayerShip { get; set; }
        #endregion

        public void StartEpisode(Episode episode)
        {
            CurrentEpisode = episode;
            CurrentLevel = 0;

            playerStatistics = new PlayerStatistics();
            playerStatistics.Reset();

            SceneManager.LoadScene(episode.Levels[CurrentLevel]);
        }
        public void RestartLevel()
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }
        public void FinishCurrentLevel(bool success)
        {
            LastLevelResult = success;

            CalculateLevelStat();

            ResultPanelController.Instance.ShowResult(playerStatistics, success);
        }
        public void AdvanceLevel()
        {
            playerStatistics.Reset();

            CurrentLevel++;

            if (CurrentEpisode.Levels.Length <= CurrentLevel) SceneManager.LoadScene(MainMenuSceneNickname);
            else SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }
        private void CalculateLevelStat()
        {
            playerStatistics.score = Player.Instance.Score;
            playerStatistics.numKills = Player.Instance.NumKills;
            playerStatistics.time = (int)LevelController.Instance.LevelTime;
        }
    }
}