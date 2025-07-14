using UnityEngine;
using UnityEngine.UI;
using SpaceShootan;
using System;

namespace TD
{
    public class MapLevel : MonoBehaviour
    {
        [SerializeField] private Episode m_episode;
        [SerializeField] private RectTransform resulPanel;
        [SerializeField] private Image[] resulImage;

        public bool IsComplete { get { return gameObject.activeSelf && resulPanel.gameObject.activeSelf; } }

        public void LoadLevel()
        {
            LevelSequenceController.Instance.StartEpiside(m_episode);
        }

        internal int Initialise()
        {
            var score = MapCompletion.Instance.GetEpisodeScore(m_episode);
            resulPanel.gameObject.SetActive(score > 0);
            for (int i = 0; i < score; i++)
            {
                resulImage[i].color = Color.white;
            }

            return score;
        }
    }
}
