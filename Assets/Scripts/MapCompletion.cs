using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShootan;
using System;

namespace TD
{
    public class MapCompletion : SingeltoneBase<MapCompletion>
    {
        public const string filename = "comletion.dat";

        [Serializable]
        private class EpisodeScore
        {
            public Episode episode;
            public int score;
        }

        public static void SaveEpisodeResult(int levelScore)
        {
            if(Instance)
            {
                
                foreach (var item in Instance.completionData)
                {
                    if (item.episode == LevelSequenceController.Instance.CurrentEpisode)
                    {
                        if (levelScore > item.score)
                        {
                            Instance.TotalScore += levelScore - item.score;
                            item.score = levelScore;
                            Saver<EpisodeScore[]>.Save(filename, Instance.completionData);
                        }
                    }
                }
            }
            else
            {
                Debug.Log($"Episode complete with score {levelScore}");
            }
        }

        [SerializeField] private EpisodeScore[] completionData;

        public int TotalScore { private set; get; }

        private new void Awake()
        {
            base.Awake();
            Saver<EpisodeScore[]>.TryLoad(filename, ref completionData);

            foreach(var episodeScore in completionData)
            {
                TotalScore += episodeScore.score;
            }
        }

        public int  GetEpisodeScore(Episode m_episode)
        {
            foreach( var data in completionData)
            {
                if (data.episode == m_episode)
                    return data.score;
            }
            return 0;
        }
    }
}
