using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShootan
{
    public class LevelSequenceController : SingeltoneBase<LevelSequenceController>
    {
        public static string MainMenuSceneNickName = "Map";

        public Episode CurrentEpisode { get; private set; }

        public int CurrentLevel { get; private set; }

        public bool LastLevelResult { get; private set; }

        public PlayerStatistics LevelStatistics { get; set; }

        public static SpaceShip PlayerShip { get; set; }

        
        public void StartEpiside(Episode e)
        {
            CurrentEpisode = e;
            CurrentLevel = 0;

            // сбрасывает статы перед начало эпизода
            LevelStatistics = new PlayerStatistics();
            LevelStatistics.Reset();

            SceneManager.LoadScene(e.Level[CurrentLevel]);
        }

        public void RestartLevel()
        {
            //SceneManager.LoadScene(CurrentEpisode.Level[CurrentLevel]);
              SceneManager.LoadScene(2);
        }

        public void FinishCurretLevel(bool success)
        {
            /* LastLevelResult = success;

             CalculateLevelStatistic();

             int bonusScore = (int)(LevelStatistics.score * CalculateTimeMultiplier(LevelStatistics.time));

             LevelStatistics.score += bonusScore;

             ResultPanelController.Instance.ShowResult(LevelStatistics, success, bonusScore);*/

            LevelResultController.Instance.Show(success);

        }

        public void AdvanceLevel()
        {
          //  LevelStatistics.Reset();

            CurrentLevel++;

            if(CurrentEpisode.Level.Length <= CurrentLevel)
            {
                SceneManager.LoadScene(MainMenuSceneNickName);
            }
            else
            {
                SceneManager.LoadScene(CurrentEpisode.Level[CurrentLevel]);
            }
        }

        private void CalculateLevelStatistic()
        {
            LevelStatistics.score = Player.Instance.Score;
            LevelStatistics.numKills = Player.Instance.NumKills;
            LevelStatistics.time = (int)LevelController.Instance.LevelTime;
        }
        [SerializeField] private int m_BestLimitTime;
        [SerializeField] private int m_NormLimitTime;

        private float CalculateTimeMultiplier(int time)
        {
            if (time < m_BestLimitTime)
            {
                return 2f;
            }
            else if (time < m_NormLimitTime)
            {
                return 1f;
            }
            else
            {
                return 0f;
            }
        }
    }

}
