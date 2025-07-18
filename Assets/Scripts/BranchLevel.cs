using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD
{
    [RequireComponent(typeof(MapLevel))]

    public class BranchLevel : MonoBehaviour
    {
        
        [SerializeField] private MapLevel rootLevel;
        [SerializeField] private Text pointText;
        [SerializeField] private int needPoints = 3;

        public void TryActivate()
        {
            gameObject.SetActive(rootLevel.IsComplete);

            if(needPoints > MapCompletion.Instance.TotalScore)
            {
                pointText.text = needPoints.ToString();
            }
            else
            {
                pointText.transform.parent.gameObject.SetActive(false);
                GetComponent<MapLevel>().Initialise();
            }
        }
    }
}