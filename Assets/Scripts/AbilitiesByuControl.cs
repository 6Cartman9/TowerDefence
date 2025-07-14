using UnityEngine;
using UnityEngine.UI;

namespace TD
{
    public class AbilitiesByuControl : MonoBehaviour
    {/*
        [SerializeField] private Abilities.FireAbility m_FireAbilities;
        [SerializeField] private Text m_FireText;
        [SerializeField] private Button m_FireButton;

        [SerializeField] private Abilities.TimeAbility m_TimeAbilities;
        [SerializeField] private Text m_TimeText;
        [SerializeField] private Button m_TimeButton;

        private void Start()
        {
            TDPlayer.Instance.DiamontUpdateSubscribe(DiamontStatusCheck);
            m_FireText.text = m_FireAbilities.FireCost.ToString();
            m_TimeText.text = m_TimeAbilities.TimeCost.ToString();
        }

        private void DiamontStatusCheck(int diamont)
        {
            if (diamont >= m_FireAbilities.FireCost != m_FireButton.interactable)
            {
                m_FireButton.interactable = !m_FireButton.interactable;
                m_FireText.color = m_FireButton.interactable ? Color.white : Color.red;
            }

            if (diamont >= m_TimeAbilities.TimeCost != m_TimeButton.interactable)
            {
                m_TimeButton.interactable = !m_TimeButton.interactable;
                m_TimeText.color = m_TimeButton.interactable ? Color.white : Color.red;
            }
        }

        public void ByuFireAbilities()
        {
            TDPlayer.Instance.TryByuFireAbilities(m_FireAbilities);
        }

        public void BuyTimeAbilities()
        {
            TDPlayer.Instance.TryByuTimeAbilities(m_TimeAbilities);
        }*/
    }
}