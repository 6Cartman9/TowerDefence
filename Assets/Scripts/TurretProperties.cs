using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShootan
{
    public enum TurretMode
    {
        Primary,
        Secondary,
        Rocket,
        Auto
    }

    [CreateAssetMenu]
    public sealed class TurretProperties : ScriptableObject
    {
        [SerializeField] private TurretMode m_Mode;
        public TurretMode Mode => m_Mode;

        [SerializeField] private Projectile m_ProjectilePrefab;
        public Projectile ProjectilePrefab => m_ProjectilePrefab;

        [SerializeField] private float m_RateOfFire;
        public float RateOfFire => m_RateOfFire;

        [SerializeField] private int m_EnetgyUsage;
        public int EnergyUsage => m_EnetgyUsage;

        [SerializeField] private int m_AmmoUsage;
        public int AmmoUsage => m_AmmoUsage;

        [SerializeField] private int m_RocketUsage;
        public int RocketUsage => m_RocketUsage;


    }

}
