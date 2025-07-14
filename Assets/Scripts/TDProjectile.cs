using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShootan;

namespace TD
{
    public class TDProjectile : Projectile
    {
        public enum DamageType { Base, Magic, BigArrow}

        [SerializeField] private Sound m_ShotSound = Sound.Arrow;
        [SerializeField] private Sound m_HitSound = Sound.Arrowhit;
        [SerializeField] private DamageType m_DamageType;

        private void Start()
        {
            m_ShotSound.Play();
        }
        protected override void OnHit(RaycastHit2D hit)
        {
            m_HitSound.Play();

            var enemy = hit.collider.transform.root.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(m_Damage, m_DamageType);
            }
        }
    }
}