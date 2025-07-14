using UnityEngine;
using UnityEngine.UI;

namespace TD
{
    public class TowerByuController : MonoBehaviour
    {

        [SerializeField] private TowerAsset m_TowerAsset;
        public void SetTowerAsset (TowerAsset asset) { m_TowerAsset = asset; }

        [SerializeField] private Text m_Text;

        [SerializeField] private Button m_Button;

        [SerializeField] private Transform m_BuildSite;

        public void SetBuildSite(Transform value)
        {
            m_BuildSite = value;
        }

        private void Start()
        {
            TDPlayer.Instance.GoldUpdateSubscribe(GoldStatusCheck);
            m_Text.text = m_TowerAsset.GoldCost.ToString();
            m_Button.GetComponent<Image>().sprite = m_TowerAsset.GUISprite;
        }

        private void GoldStatusCheck(int gold)
        {
            if(gold >= m_TowerAsset.GoldCost != m_Button.interactable)
            {
                m_Button.interactable = !m_Button.interactable;
                m_Text.color = m_Button.interactable ? Color.white : Color.red;
            }
        }

        public void Byu()
        {
            
            TDPlayer.Instance.TryBuild(m_TowerAsset, m_BuildSite);
            BuiltSite.HIdeControls();
        }
    }
}
