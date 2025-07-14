using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShootan
{
    public interface ILevelCondition
    {
        bool IsCompleted { get; }
    }

    public class LevelController : SingeltoneBase<LevelController>
    {
        [SerializeField] protected float m_ReferenceTime;
        public float ReferenceTime => m_ReferenceTime;

        [SerializeField] protected UnityEvent m_EventLevelCompleted;

        private ILevelCondition[] m_Conditions;

        private bool m_isLevelCompleted;

        private float m_LevelTime;
        public float LevelTime => m_LevelTime;

        protected void Start()
        {
            m_Conditions = GetComponentsInChildren<ILevelCondition>();

        }

      
        void Update()
        {
            if(!m_isLevelCompleted)
            {
                m_LevelTime += Time.deltaTime;

                CheckLevelConditions();
            }
        }

        private void CheckLevelConditions()
        {
            if (m_Conditions == null || m_Conditions.Length == 0) return;

            int numCompleted = 0;

            foreach(var v in m_Conditions)
            {
                if (v.IsCompleted)
                    numCompleted++;
            }

            if(numCompleted == m_Conditions.Length)
            {
                m_isLevelCompleted = true;
                m_EventLevelCompleted?.Invoke();

                LevelSequenceController.Instance?.FinishCurretLevel(true);
            }

           
        }
    }

}
