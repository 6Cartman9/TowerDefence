using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using SpaceShootan;

namespace TD
{
    public class ClickProtection : SingeltoneBase<ClickProtection>, IPointerClickHandler
    {
        private Image blocked;

        private void Start()
        {
            blocked = GetComponent<Image>();
            blocked.enabled = false;
        }

        private Action<Vector2> m_OnClickAction;

        public void Avtivate(Action<Vector2> mouseAction)
        {
            blocked.enabled = true;
            m_OnClickAction = mouseAction;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            blocked.enabled = false;
            m_OnClickAction(eventData.pressPosition);
            m_OnClickAction = null;
        }
    }
}