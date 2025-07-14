using UnityEngine;
using SpaceShootan;

namespace TD
{
    [CreateAssetMenu]
    public partial class TowerAsset : ScriptableObject
    {
        public int GoldCost;
        public Sprite TowerSprite;
        public Sprite GUISprite;
        // public GameObject TowerPrefab;
        public TurretProperties turretProperties;

        [SerializeField] private UpgradesAsset requiresUpgrade;
        [SerializeField] private int requiredUpgradeLevel;

        public bool IsAvailable() => !requiresUpgrade ||
            requiredUpgradeLevel <= Upgrades.GetUpgradeLevel(requiresUpgrade);

        public TowerAsset[] m_UpgradeTo;

    }
}
