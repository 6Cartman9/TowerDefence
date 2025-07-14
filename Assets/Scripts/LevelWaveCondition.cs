using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShootan;

namespace TD
{
    public class LevelWaveCondition : MonoBehaviour, ILevelCondition
    {
        private bool isCompleted;

        void Start()
        {
            FindObjectOfType<EnemyWaveManager>().OnAllWavesDead += () => { isCompleted = true; };
        }

        public bool IsCompleted { get { return isCompleted; } }
    }
}
