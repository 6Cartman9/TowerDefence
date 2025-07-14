using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace TD
{
    public class UpgradeShop : MonoBehaviour
    {

        [SerializeField] private int money;
        [SerializeField] private Text moneyText;
        [SerializeField] private BuyUpgrade[] sales;

        void Start()
        {
           
            foreach (var slot in sales)
            {
                slot.Initialize();
                slot.transform.Find("BuyButton").GetComponent<Button>().onClick.AddListener(UpdateMoney);
            }

            UpdateMoney();
        }

        public void UpdateMoney()
        {
            money = MapCompletion.Instance.TotalScore;
            money -= Upgrades.GetTotalCost();
            moneyText.text = money.ToString();

            foreach(var slot in sales)
            {
                slot.CheckCost(money);
            }

        }

    }
}