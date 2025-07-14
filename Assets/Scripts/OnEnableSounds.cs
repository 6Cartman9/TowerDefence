using UnityEngine;

namespace TD
{
    public class OnEnableSounds : MonoBehaviour
    {
        [SerializeField] private Sound m_Sound;

        private void OnEnable()
        {
            m_Sound.Play();
        }
    }
}