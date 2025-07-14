using System.Collections;
using UnityEngine;
using System;
using SpaceShootan;
using UnityEngine.UI;

namespace TD
{
    public class Abilities : SingeltoneBase<Abilities>
    {
        [Serializable]
        public class FireAbility
        {
            [SerializeField] private int m_Damage;
            [SerializeField] private float m_FireCooldown;
           // public int FireCost => m_FireCost;

            public void Use() 
            {
                ClickProtection.Instance.Avtivate((Vector2 v) =>
                {
                    Vector3 position = v;
                    position.z = -Camera.main.transform.position.z;
                    position = Camera.main.ScreenToWorldPoint(position);
                    foreach( var collider in Physics2D.OverlapCircleAll(position, 3))
                    {
                        if(collider.transform.parent.TryGetComponent<Enemy>(out var enemy))
                        {
                            enemy.TakeDamage(m_Damage, TDProjectile.DamageType.Magic);
                        }
                    }
                });
                Instance.StartCoroutine(TimeAbilityFireButton());


                IEnumerator TimeAbilityFireButton()
                {
                    Instance.m_FireButton.interactable = false;
                    yield return new WaitForSeconds(m_FireCooldown);
                    Instance.m_FireButton.interactable = true;
                }

            }
        }

        [Serializable]
        public class TimeAbility
        {
            [SerializeField] private float m_Duration;
           // [SerializeField] private int m_TimeCost;
           // public int TimeCost => m_TimeCost;

            [SerializeField] private float m_Cooldown;

            public void Use()
            {
                void Slow(Enemy ship)
                {
                    ship.GetComponent<SpaceShip>().HalfMaxLinearVelocity();
                }

                foreach (var ship in FindObjectsOfType<SpaceShip>())
                    ship.HalfMaxLinearVelocity();

                EnemyWaveManager.OnEnemySpawn += Slow;

                IEnumerator Restore()
                {
                    yield return new WaitForSeconds(m_Duration);
                    foreach (var ship in FindObjectsOfType<SpaceShip>())
                        ship.RestoreMaxLinearVelocity();
                    EnemyWaveManager.OnEnemySpawn -= Slow;
                }

                Instance.StartCoroutine(Restore());

                IEnumerator TimeAbilityButton()
                {
                    Instance.m_TimeButton.interactable = false;
                    yield return new WaitForSeconds(m_Cooldown);
                    Instance.m_TimeButton.interactable = true;
                }
                Instance.StartCoroutine(TimeAbilityButton());
            }
        }
        [SerializeField] private Button m_TimeButton;
        [SerializeField] private Button m_FireButton;

       // [SerializeField] private GameObject m_FireAbilityButton;
      //  [SerializeField] private GameObject m_TimeAbilityButton;
      //  [SerializeField] private UpgradesAsset m_AbFire;
       // [SerializeField] private UpgradesAsset m_AbTime;
      //  [SerializeField] private Image m_TargetingCircle;

        [SerializeField] private FireAbility m_FireAbility;
        public void UseFireAbility() => m_FireAbility.Use(); 

        [SerializeField] private TimeAbility m_TimeAbility;
        public void UseTimeAbility() => m_TimeAbility.Use();
/*
        private void Start()
        {
            var levelfire = Upgrades.GetUpgradeLevel(m_AbFire);
            var leveltime = Upgrades.GetUpgradeLevel(m_AbTime);
            if(levelfire == 0)
            {
                m_FireAbilityButton.SetActive(false);
            }
            else
            { m_FireAbilityButton.SetActive(true); }

            if (leveltime == 0)
            {
                m_TimeAbilityButton.SetActive(false);
            }
            else
            { m_TimeAbilityButton.SetActive(true); }

        }*/
    }
}