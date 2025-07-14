using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShootan
{
    [CreateAssetMenu]
    public class Episode : ScriptableObject
    {
        [SerializeField] private string m_EpisodeName;
        public string EpisodeName => m_EpisodeName;

        [SerializeField] private string[] m_Level;
        public string[] Level => m_Level;

        [SerializeField] private Sprite m_PreviewImage;
        public Sprite PreviewImage => m_PreviewImage;
    }

}
