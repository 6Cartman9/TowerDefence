using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TD;

namespace SpaceShootan
{
    public class EntitySpawner : Spawner
    {
        [SerializeField] private Entity[] m_EntityPrefabs;

        protected override GameObject GenerateSpawnedEnity()
        {
            int index = Random.Range(0, m_EntityPrefabs.Length);

            return Instantiate(m_EntityPrefabs[index].gameObject);
        }

       
    }

}
