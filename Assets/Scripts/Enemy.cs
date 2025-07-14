using UnityEngine;
using SpaceShootan;
using System;

namespace TD
{
    [RequireComponent(typeof(Destructible))] 
    [RequireComponent(typeof(TDPatrolController))] 
    public class Enemy : MonoBehaviour
    {
        public enum ArmorType { Base = 0, Magic = 1, Heavey = 2}

        private static Func<int, TDProjectile.DamageType, int, int>[] ArmorDamageFunction =
        {
            (int power, TDProjectile.DamageType type, int armor) =>
            {//ArmorType.Base
                switch (type)
                {
                    case TDProjectile.DamageType.Magic: return power;
                    default: return Mathf.Max(power - armor, 1); 
                }
            },

            (int power, TDProjectile.DamageType type, int armor) =>
            {//ArmorType.Magic
                if(TDProjectile.DamageType.Base == type)
                    armor = armor / 2;

                return Mathf.Max(power - armor, 1);
            },

             (int power, TDProjectile.DamageType type, int armor) =>
            {//ArmorType.Heavy
                if(TDProjectile.DamageType.Base == type || TDProjectile.DamageType.Magic == type)
                    armor = armor / 2;

                return Mathf.Max(power - armor, 1);
            },
        };

        [SerializeField] private int m_Damage = 1;
        [SerializeField] private int m_Gold = 1;
      //  [SerializeField] private int m_Diamont = 1;
        [SerializeField] private int m_Armor = 1;
        [SerializeField] private ArmorType m_ArmorType;

        private Destructible m_Destructible;

        private void Awake()
        {
            m_Destructible = GetComponent<Destructible>();
        }

        public event Action OnEnd;
        private void OnDestroy()
        {
            OnEnd?.Invoke();
        }

        public void Use(EnemyAsset asset)
        {
            var sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();

            sr.color = asset.color;

            sr.transform.localScale = new Vector3(asset.spriteScale.x, asset.spriteScale.y, 1);

            sr.GetComponent<Animator>().runtimeAnimatorController = asset.animations;

            GetComponent<SpaceShip>().Use(asset);

            GetComponentInChildren<CircleCollider2D>().radius = asset.radius;

            m_Damage = asset.damage;
            m_Gold = asset.gold;
            m_Armor = asset.armor;
           // m_Diamont = asset.diamont;
            m_ArmorType = asset.armorType;

        }

        public void DamagePlayer()
        {
           TDPlayer.Instance.ReduceLife(m_Damage);
        }

        public void GiveGoldToPlayer()
        {
            TDPlayer.Instance.ChangeGold(m_Gold);
          //  TDPlayer.Instance.ChangeDiamont(m_Diamont);
        }

        public void TakeDamage(int damage, TDProjectile.DamageType damageType)
        {
            m_Destructible.ApplyDamage(ArmorDamageFunction[(int)m_ArmorType](damage, damageType, m_Armor));
        }
    }

}
