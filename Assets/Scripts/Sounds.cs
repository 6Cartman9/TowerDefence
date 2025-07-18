using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TD
{
    [CreateAssetMenu()]
    public class Sounds : ScriptableObject
    {
        [SerializeField] public AudioClip[] m_Sounds;
        public AudioClip this[Sound s] => m_Sounds[(int) s];
    }

#if UNITY_EDITOR

    [CustomEditor(typeof(Sounds))]
    
    public class SoundsInspector: Editor
    {
        private static readonly int soundCount = Enum.GetValues(typeof(Sound)).Length;
        private new Sounds target => base.target as Sounds;

        public override void OnInspectorGUI()
        {
            if(target.m_Sounds.Length < soundCount)
            {
                Array.Resize(ref target.m_Sounds, soundCount);
            }

            for (int i = 0; i < target.m_Sounds.Length; i++)
            {
                target.m_Sounds[i] = EditorGUILayout.ObjectField($"{(Sound)i}:",
                    target.m_Sounds[i], typeof(AudioClip), false) as AudioClip;
            }
        }
    }

#endif
}