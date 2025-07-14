using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD
{
    [CreateAssetMenu]
    public sealed class EnemyAsset : ScriptableObject
    {
        [Header("Внешний вид")]    
        public Color color = Color.white;
        public Vector2 spriteScale = new Vector2(3, 3);
        public RuntimeAnimatorController animations;

        [Header("Параметры")]
        public float m_MoveSpeed = 1;
        public int hp = 1;
        public int armor = 0;
        public Enemy.ArmorType armorType;
        public int score = 1;
        public float radius = 0.25f;
        public int damage = 1;
        public int gold = 1;
        //public int diamont = 1;

    }
}
