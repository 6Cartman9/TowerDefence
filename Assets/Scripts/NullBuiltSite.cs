using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TD
{

    public class NullBuiltSite : BuiltSite
    {
        public override void OnPointerDown(PointerEventData eventData)
        {
            HIdeControls();
        }
    }
}