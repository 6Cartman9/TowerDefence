using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TD;

namespace SpaceShootan
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy m_EnemyPrafab;
        [SerializeField] private Path m_Path;
        [SerializeField] private EnemyAsset[] m_EnemyAsset;


        protected override GameObject GenerateSpawnedEnity()
        {
            var n = Instantiate(m_EnemyPrafab);

            n.Use(m_EnemyAsset[Random.Range(0, m_EnemyAsset.Length)]);

            n.GetComponent<TDPatrolController>().SetPath(m_Path);

            return n.gameObject;
        }
                
    }

}
