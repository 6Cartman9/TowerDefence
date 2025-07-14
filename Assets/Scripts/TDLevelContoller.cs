using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShootan;

namespace TD
{
    public class TDLevelContoller : LevelController
    {
        private int levelScore = 3;

        private new void Start()
        {
            base.Start();
            TDPlayer.Instance.OnPlayerDead += () =>
            {
                StopLevelActivity();
                LevelResultController.Instance.Show(false);
            };

            m_ReferenceTime += Time.time;

            m_EventLevelCompleted.AddListener(() =>
            {
                StopLevelActivity();

                if(m_ReferenceTime <= Time.time)
                {
                    levelScore -= 1;
                }

                MapCompletion.SaveEpisodeResult(levelScore);
            });

            void LifeScoreChange(int _)
            {
                levelScore -= 1;
                TDPlayer.Instance.OnLifeUpdate -= LifeScoreChange;
            }
            TDPlayer.Instance.OnLifeUpdate += LifeScoreChange;
        }

        private void StopLevelActivity()
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.GetComponent<SpaceShip>().enabled = false;
                enemy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

            void DisableAll<Q>() where Q: MonoBehaviour
            {
                foreach(var obj in FindObjectsOfType<Q>())
                {
                    obj.enabled = false;
                }
            }

            DisableAll<EnemyWave>();
            DisableAll<Projectile>();
            DisableAll<Tower>();
            DisableAll<NextWaveGUI>();
        }
    }
}
