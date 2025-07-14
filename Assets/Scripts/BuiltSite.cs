using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace TD
{
    public class BuiltSite : MonoBehaviour, IPointerDownHandler
    {
        public TowerAsset[] m_BuildableTowers;
        public void SetBuildableTower (TowerAsset[] towers) 
        {
            if(towers == null || towers.Length == 0)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                m_BuildableTowers = towers;
            }
        }

        public static Action<BuiltSite> OnClickEvent;

        public static void HIdeControls()
        {
            OnClickEvent(null);
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnClickEvent(this);
        }

    }

}
