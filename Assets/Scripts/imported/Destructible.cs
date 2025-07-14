using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TD;

namespace SpaceShootan
{
    /// <summary>
    /// Уничтожаемый объект на сцене. У чего есть хп
    /// </summary>
    public class Destructible : Entity
    {
        #region Properties
        /// <summary>
        /// Объект игнорирует повреждение
        /// </summary>
        [SerializeField] private bool m_Indestructible;
      
        /// <summary>
        /// Стартовое значение хп
        /// </summary>
        [SerializeField] private int m_HitPoints;

        /// <summary>
        /// Текущее хп
        /// </summary>
        [SerializeField] private int m_CurrentHitPoints;
        public int HitPoints => m_CurrentHitPoints;

        #endregion

        #region Unity Events

        protected virtual void Start()
        {
            m_CurrentHitPoints = m_HitPoints;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Применение урона по объекту
        /// </summary>
        /// <param name="damage">Урон наносимый объекту</param>
        public void ApplyDamage(int damage)
        {
            if (m_Indestructible) return;

            m_CurrentHitPoints -= damage;

            if (m_CurrentHitPoints <= 0)
                OnDeath();
        }

        #endregion

        protected virtual void OnDeath()
        {
            m_EventOnDeath?.Invoke();

            Destroy(gameObject);
        }

        private static HashSet<Destructible> m_AllDestructible;

        public static IReadOnlyCollection<Destructible> AllDestructible => m_AllDestructible;

        protected virtual void OnEnable()
        {
            if (m_AllDestructible == null)
                m_AllDestructible = new HashSet<Destructible>();

            m_AllDestructible.Add(this);
        }

        protected virtual void OnDestroy()
        {
            m_AllDestructible.Remove(this);
        }

        public const int TeamIdNeutral = 0;

        [SerializeField] private int m_TeamID;
        public int TeamID => m_TeamID;

        [SerializeField] private UnityEvent m_EventOnDeath;
        public UnityEvent EventOnDeath => m_EventOnDeath;

        public void ActiveIndestructible(int x)
        {
            if (x == 1) m_Indestructible = true;
            if (x == 2) m_Indestructible = false;
        }

        [SerializeField] private float m_PredictionMultiply;
        public Vector3 MakeLead()
        {
            Rigidbody2D rb = gameObject.GetComponentInParent<Rigidbody2D>();
            Vector3 targetVel = rb.velocity;
            Vector3 newTarget = transform.position + targetVel * m_PredictionMultiply;

            return newTarget;
        }

        #region Score
        [SerializeField] private int m_ScoreValue;
        public int ScoreValue => m_ScoreValue;

        #endregion

        protected void Usee(EnemyAsset asset)
        {
            m_HitPoints = asset.hp;
            m_ScoreValue = asset.score;
        }
    }

}
