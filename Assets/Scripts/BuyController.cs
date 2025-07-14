using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD
{
    public class BuyController : MonoBehaviour
    {
        [SerializeField] private TowerByuController m_TowerBuyPrefab;
        private List<TowerByuController> m_ActiveControl;

        private RectTransform m_RectTransform;

        private void Awake()
        {
            m_RectTransform = GetComponent<RectTransform>();
            BuiltSite.OnClickEvent += MoveToBuiltSite;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            BuiltSite.OnClickEvent -= MoveToBuiltSite;
        }

        private void MoveToBuiltSite(BuiltSite builtSite)
        {
            if(builtSite)
            {
                var position = Camera.main.WorldToScreenPoint(builtSite.transform.root.position);
                m_RectTransform.anchoredPosition = position;
                m_ActiveControl = new List<TowerByuController>();

                foreach(var asset in builtSite.m_BuildableTowers)
                {
                    if (asset.IsAvailable())
                    {
                        var newControl = Instantiate(m_TowerBuyPrefab, transform);
                        m_ActiveControl.Add(newControl);
                        newControl.SetTowerAsset(asset);
                    }
                }

                if (m_ActiveControl.Count > 0)
                {
                    gameObject.SetActive(true);

                    var angle = 360 / m_ActiveControl.Count;
                    for (int i = 0; i < m_ActiveControl.Count; i++)
                    {
                        var offset = Quaternion.AngleAxis(angle * i, Vector3.forward) * (Vector3.up * 80);
                        m_ActiveControl[i].transform.position += offset;
                    }

                    foreach (var tbc in GetComponentsInChildren<TowerByuController>())
                    {
                        tbc.SetBuildSite(builtSite.transform.root);
                    }
                }
            }
            else
            {
               // if(m_ActiveControl != null)
                
                    foreach (var control in m_ActiveControl) Destroy(control.gameObject);
                    m_ActiveControl.Clear();
                
                gameObject.SetActive(false);
            }
        }
    }
}
