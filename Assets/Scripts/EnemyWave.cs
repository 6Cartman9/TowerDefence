using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD
{
    public class EnemyWave: MonoBehaviour
    {

        public static Action<float> OnWavePrepare;

        [Serializable]
        private class Squad
        {
            public EnemyAsset asset;
            public int count;
        }

        [Serializable]
        private class PathGroup
        {
            public Squad[] squeds;
        }

        [SerializeField] private PathGroup[] groups;
        [SerializeField] private float prepareTime = 10f;

        public float GetReaminingTime() { return prepareTime -= Time.time; }

        private void Awake()
        {
            enabled = false;
        }

        private event Action OnWaveReady;

        public void Prepare(Action spawnEnemies)
        {
            OnWavePrepare?.Invoke(prepareTime);
            prepareTime += Time.time;
            enabled = true;
            OnWaveReady += spawnEnemies;
        }

        private void Update()
        {
            if(Time.time >= prepareTime)
            {
                enabled = false;
                OnWaveReady?.Invoke();
            }
        }

        [SerializeField] private EnemyWave next;
        public EnemyWave PrepareNext(Action spawnEnemies)
        {
            OnWaveReady -= spawnEnemies;
           if(next) next.Prepare(spawnEnemies);
            return next;
        }

        public IEnumerable<(EnemyAsset asset, int count, int pathIndex)> EnumerateSquads()
        {
            for(int i = 0; i < groups.Length; i++)
            {
                foreach(var squad in groups[i].squeds)
                {
                    yield return (squad.asset, squad.count, i);
                }
            }
        }
    }
}