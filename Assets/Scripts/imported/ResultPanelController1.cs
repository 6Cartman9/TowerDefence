using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShootan
{
    public class ResultPanelController : SingeltoneBase<ResultPanelController>
    {
        [SerializeField] private Text m_Kills;
        [SerializeField] private Text m_Time;
        [SerializeField] private Text m_Score;

        [SerializeField] private Text m_Result;

        [SerializeField] private Text m_ButtonNextText;

        [SerializeField] private Text m_BonusScore;

        private bool m_Success;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowResult(PlayerStatistics levelResult, bool success, int bonusScore)
        {
            gameObject.SetActive(true);

            m_Success = success;

            m_Result.text = success ? "Win" : "Lose";

            m_ButtonNextText.text = success ? "Next" : "Restart";

            m_Kills.text = "NumKills : " + levelResult.numKills.ToString();
            m_Time.text = "Time : " + levelResult.time.ToString();
            m_Score.text = "Score : " + levelResult.score.ToString();
            m_BonusScore.text = "Bonus Score : " + bonusScore.ToString();

            Time.timeScale = 0;
        }

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);

            Time.timeScale = 1;

            if(m_Success)
            {
                LevelSequenceController.Instance.AdvanceLevel();
            }
            else
            {
               LevelSequenceController.Instance.RestartLevel();
            }
        }
    }

}
