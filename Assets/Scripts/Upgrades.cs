using System;
using UnityEngine;
using SpaceShootan;

namespace TD
{
    public class Upgrades : SingeltoneBase<Upgrades>
    {
        public const string filename = "upgrade.dat";

        [Serializable]
        private class UpgradeSave
        {
            public UpgradesAsset asset;
            public int level = 0;
        }

        [SerializeField] private UpgradeSave[] save;

        private new void Awake()
        {
            base.Awake(); 
            Saver<UpgradeSave[]>.TryLoad(filename, ref save);

        }

        public static void BuyUpgrade(UpgradesAsset asset)
        {
            foreach (var upgrade in Instance.save)
            {
                if(upgrade.asset == asset)
                {
                    upgrade.level += 1;
                    Saver<UpgradeSave[]>.Save(filename, Instance.save);

                }
            }
        }

        public static int GetTotalCost()
        {
            int result = 0; 

            foreach(var upgrade in Instance.save)
            {
                for(int i = 0; i < upgrade.level; i++)
                {
                    result += upgrade.asset.costByLevel[i];
                }
            }

            return result;
        }

        public static int GetUpgradeLevel(UpgradesAsset asset)
        {
            foreach (var upgrade in Instance.save)
            {
                if (upgrade.asset == asset)
                {
                    return upgrade.level;   
                }
            }

            return 0;
        }
    }
}