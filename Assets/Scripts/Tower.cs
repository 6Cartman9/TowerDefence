using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShootan;

namespace TD
{
    public class Tower : MonoBehaviour
    {

        [SerializeField] private float m_Radius;
        private float m_Lead = 0.3f;
        private Turret[] turrets;
        private Rigidbody2D target = null;


        public void Use(TowerAsset asset)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = asset.TowerSprite;
            turrets = GetComponentsInChildren<Turret>();
            foreach (var turret in turrets)
            {
                turret.AssingLoadout(asset.turretProperties);
            }
            GetComponentInChildren<BuiltSite>().SetBuildableTower(asset.m_UpgradeTo);
        }

        private void Update()
        {
            if(target)
            {
                if(Vector3.Distance(target.transform.position, transform.position) <= m_Radius)
                {
                    foreach (var turret in turrets)
                    {
                        turret.transform.up = target.transform.position - turret.transform.position + (Vector3)target.velocity * m_Lead;
                        turret.Fire();
                    }
                        
                }
                else
                {
                    target = null;
                }
                
            }
            else
            {
                var enter = Physics2D.OverlapCircle(transform.position, m_Radius);

                if (enter)
                {
                    target = enter.transform.root.GetComponent<Rigidbody2D>();

                }
            }
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(transform.position, m_Radius);
        }

    }

}
