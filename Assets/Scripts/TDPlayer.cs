using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShootan;
using System;

namespace TD
{
    public class TDPlayer : Player
    {
        public static new TDPlayer Instance
        {
            get { return Player.Instance as TDPlayer; }
        }

        public event Action<int> OnGoldUpdate;

        public void GoldUpdateSubscribe(Action<int> act)
        {
            OnGoldUpdate += act;
            act(Instance.m_Gold);
        }

      //  public event Action<int> OnDiamontUpdate;

      /*  public void DiamontUpdateSubscribe(Action<int> act)
        {
            OnDiamontUpdate += act;
            act(Instance.m_Diamont);
        }
      */
        public event Action<int> OnLifeUpdate;

        public void LifeUpdateSubscribe(Action<int> act)
        {
            OnLifeUpdate += act;
            act(Instance.NumLives);
        }

        [SerializeField] private int m_Gold = 0;
       // [SerializeField] private int m_Diamont = 0;
       
        public void ChangeGold(int gold)
        {
            m_Gold += gold;
            OnGoldUpdate(m_Gold);
        }

      /*  public void ChangeDiamont(int diamont)
        {
            m_Diamont += diamont;
            OnDiamontUpdate(m_Diamont);
        }
      */
        public void ReduceLife(int life)
        {
            TakeDamege(life);
            OnLifeUpdate(NumLives);
        }

        [SerializeField] private Tower m_towerPrefab;
        public void TryBuild(TowerAsset m_TowerAsset, Transform m_BuildSite)
        {
            ChangeGold(-m_TowerAsset.GoldCost);
            var tower = Instantiate(m_towerPrefab, m_BuildSite.position, Quaternion.identity);
            tower.Use(m_TowerAsset);
            tower.GetComponentInChildren<SpriteRenderer>().sprite = m_TowerAsset.TowerSprite;
            Destroy(m_BuildSite.gameObject);
        }
/*
        public void TryByuFireAbilities(Abilities.FireAbility m_FireAbilities)
        {
            ChangeDiamont(-m_FireAbilities.FireCost);
        } 
        public void TryByuTimeAbilities(Abilities.TimeAbility m_TimeAbilities)
        {
            ChangeDiamont(-m_TimeAbilities.TimeCost);
        }*/

        [SerializeField] private UpgradesAsset lifeUpgrede;
        [SerializeField] private UpgradesAsset moneyUpgrede;
       // [SerializeField] private UpgradesAsset fireAbilityUpgrede;
      //  [SerializeField] private UpgradesAsset timeAbilityUpgrede;

        private void Start()
        {
            var levelLife = Upgrades.GetUpgradeLevel(lifeUpgrede);
            var levelMoney = Upgrades.GetUpgradeLevel(moneyUpgrede);
           // var levelFireAbility = Upgrades.GetUpgradeLevel(fireAbilityUpgrede);
            TakeDamege(-levelLife * 5);
            m_Gold = m_Gold + (levelMoney * 10);
            
        }
    }   
}
