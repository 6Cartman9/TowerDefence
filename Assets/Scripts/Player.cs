using UnityEngine;
using System;

namespace SpaceShootan
{
    public class Player : SingeltoneBase<Player>
    {
        [SerializeField] private int m_NumLives;
        public int NumLives { get { return m_NumLives; } }

        public event Action OnPlayerDead;
        
        [SerializeField] private SpaceShip m_Ship;
        [SerializeField] private GameObject m_PlayerShipPrefab;
        public SpaceShip ActiveShip => m_Ship;

       // [SerializeField] private CameraController m_cameraController;
       // [SerializeField] private MovementController m_movementController;

        protected override void Awake()
        {
            base.Awake();

            if (m_Ship != null)
                Destroy(m_Ship.gameObject);
        }
       

        private void Start()
        {
            if(m_Ship)
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

        private void OnShipDeath()
        {
            m_NumLives--;

            if (m_NumLives > 0) 
                Respawn();
            else
                LevelSequenceController.Instance.FinishCurretLevel(false);
        }

        public void TakeDamege(int damage)
        {
            m_NumLives -= damage;
            if(m_NumLives <= 0)
            {
                m_NumLives = 0;
                OnPlayerDead?.Invoke();
             
            }
        }

        private void Respawn()
        {
            if(LevelSequenceController.PlayerShip != null)
            {
                var newPlayerShip = Instantiate(LevelSequenceController.PlayerShip);

                m_Ship = newPlayerShip.GetComponent<SpaceShip>();

              //  m_cameraController.SetTarget(m_Ship.transform);
              //  m_movementController.SetTargetShip(m_Ship);

                m_Ship.EventOnDeath.AddListener(OnShipDeath);
            }
          
        }

        #region Score
        public int Score { get; private set; }
        public int NumKills { get; private set; }

        public void AddKill()
        {
            NumKills++;
        }

        public void AddScore(int num)
        {
            Score += num;
        }
        #endregion
    }
}
