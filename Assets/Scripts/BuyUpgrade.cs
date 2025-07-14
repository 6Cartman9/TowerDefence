using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD
{
    public class BuyUpgrade : MonoBehaviour
    {
        [SerializeField] private UpgradesAsset asset;
        [SerializeField] private Image upgradeIcon;
        [SerializeField] private Text level, costText;
        [SerializeField] private Button buyButtom;
        private int costNumber = 0; 

        public void Initialize()
        {
            upgradeIcon.sprite = asset.sprite;
            var savedLevel = Upgrades.GetUpgradeLevel(asset);

            if(savedLevel >= asset.costByLevel.Length)
            {
                level.text = $"Lvl: {savedLevel + 1} (Max)";
                buyButtom.interactable = false;
                buyButtom.transform.Find("Image (1)").gameObject.SetActive(false); 
                buyButtom.transform.Find("Buy").gameObject.SetActive(false);
                costText.text = "X";
                costNumber = int.MaxValue;
            }
            else
            {
                level.text = $"Lvl: {savedLevel + 1}";
                costNumber = asset.costByLevel[savedLevel];
                costText.text = costNumber.ToString();
            }
        }

        public void CheckCost(int money)
        {
            buyButtom.interactable = money >= costNumber;
        }

        public void Buy()
        {
            Upgrades.BuyUpgrade(asset);
            Initialize();
        }

    }
}
