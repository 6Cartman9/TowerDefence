using System;
using System.Collections;
using TD;
using UnityEngine;

namespace SpaceShootan
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceShip : Destructible
    {
        /// <summary>
        /// ����� ��� ������� ��������� �������
        /// </summary>
        [Header("Space ship")]
        [SerializeField] private float m_Mass;

        /// <summary>
        /// ��������� ���� �����
        /// </summary>
        [SerializeField] private float m_Thrust;

        /// <summary>
        /// ��������� ����
        /// </summary>
        [SerializeField] private float m_Mobility;

        /// <summary>
        /// ���� �������� ��������
        /// </summary>
        [SerializeField] private float m_MaxLinearVelocity;
        //public float MaxLinearVelocity => m_MaxLinearVelocity;
        private float m_MaxVelocityBackup;
        public void HalfMaxLinearVelocity()
        {
            m_MaxVelocityBackup = m_MaxLinearVelocity;
            m_MaxLinearVelocity /= 4; 
        }
        public void RestoreMaxLinearVelocity() { m_MaxLinearVelocity = m_MaxVelocityBackup; }

        /// <summary>
        /// ���� ������������ �������� � ������/���
        /// </summary>
        [SerializeField] private float m_MaxAngularVelocity;
        public float MaxAngularVelocity => m_MaxAngularVelocity;

        [SerializeField] private Sprite m_PreviewImage;
        public Sprite PreviewImage => m_PreviewImage;

        [SerializeField] private int m_HP;
        public int Hp => m_HP;

        /// <summary>
        /// ���������� ������ �� ������
        /// </summary>
        private Rigidbody2D m_Rigid;
        public Rigidbody2D m_Rigidbody => m_Rigid;

        // �����, �� ������� ������� ����� �������
       private float m_SpeedBoostDuration;

        // �����, ����� ��������� ����� ��������
       private float m_SpeedBoostEndTime;
       

        private float m_IndestructibleBoostDuration;
        private float m_IndestructibleBoostEndTime;

        [SerializeField] GameObject m_Shield;


        #region Public API

        /// <summary>
        /// ���������� �������� ����� -1.0 �� 1.0
        /// </summary>
        public float ThrustControl { get; set; }

        /// <summary>
        /// ���������� ������������ �����  -1.0 �� 1.0
        /// </summary>
        public float TorqueControl { get; set; }
        public bool IsPlayerShip { get; internal set; }
        #endregion

        #region Unity Events
        protected override void Start()
        {
            base.Start();

            m_Rigid = GetComponent<Rigidbody2D>();
            m_Rigid.mass = m_Mass;

            m_Rigid.inertia = 1;

           // InitOffensive();
        }

      
        private void FixedUpdate()
        {
            UpdateRigidBody();

           // UpdateEnergyRegen();

            // ���������, ������� �� ��������� � ���������� �� ���
            if (m_SpeedBoostDuration > 0 && Time.time > m_SpeedBoostEndTime)
            {
                // ���������� ���������
                m_SpeedBoostDuration = 0;
                ThrustControl = 0;
            } 
            
            if (m_IndestructibleBoostDuration > 0 && Time.time > m_IndestructibleBoostEndTime)
            {
                // ���������� 
                m_IndestructibleBoostDuration = 0;
                ActiveIndestructible(2);
                m_Shield.SetActive(false);
            }

        }

        #endregion
        /// <summary>
        /// ����� ���������� ��� ������� ��� ��������
        /// </summary>
        private void UpdateRigidBody()
        {
            if (m_SpeedBoostDuration > 0)
            {
                m_Rigid.AddForce(ThrustControl * m_Thrust * transform.up * Time.fixedDeltaTime * 2, ForceMode2D.Force);
            }
            else
            {
                m_Rigid.AddForce(ThrustControl * m_Thrust * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);
            }

            m_Rigid.AddForce(-m_Rigid.velocity * (m_Thrust / m_MaxLinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
            
            m_Rigid.AddTorque(TorqueControl * m_Mobility * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddTorque(-m_Rigid.angularVelocity * (m_Mobility / m_MaxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

        }
        /// <summary>
        /// TODO: draw - ��������� ��������
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool DrawEnergy(int count)
        {
                return true;
        }

        public bool DrawAmmo(int count)
        {
            return true;
        }

        public bool DrawRocket(int count)
        {
            return true;
        }

        public void Fire(TurretMode mode)
        {
            return;
        }



        /*
        [SerializeField] private Turret[] m_Turrets;

       

        [SerializeField] private int m_MaxEnergy;
        [SerializeField] private int m_MaxAmmo;
        [SerializeField] private int m_MaxRocket;
        [SerializeField] private int m_EnergyRegenPerSec;

        private float m_PrimaryEnergy;
        private int m_SecondaryAmmo;
        private int m_RocketAmmo;
    
        public void AddEnergy(int en)
        {
            m_PrimaryEnergy = Mathf.Clamp(m_PrimaryEnergy + en, 0, m_MaxEnergy);
        }

        public void AddAmmo(int ammo)
        {
            m_SecondaryAmmo = Mathf.Clamp(m_SecondaryAmmo + ammo, 0, m_MaxAmmo);
        }

        public void AddRocket(int rocket)
        {
            m_RocketAmmo = Mathf.Clamp(m_RocketAmmo + rocket, 0, m_MaxRocket);
        }

        private void InitOffensive()
        {
            m_PrimaryEnergy = m_MaxEnergy;
            m_SecondaryAmmo = m_MaxAmmo;
            m_RocketAmmo = m_MaxRocket;
        }

        private void UpdateEnergyRegen()
        {
            m_PrimaryEnergy += (float)m_EnergyRegenPerSec * Time.fixedDeltaTime;
            m_PrimaryEnergy = Mathf.Clamp(m_PrimaryEnergy, 0, m_MaxEnergy);
        }

      

        public void AssingWeapon(TurretProperties prop)
        {
            for (int i = 0; i < m_Turrets.Length; i++)
            {
                m_Turrets[i].AssingLoadout(prop);
            }
        }

        /// <summary>
        /// ����� ��� ��������� ��������� �������
        /// </summary>
        /// <param name="duration">������������ ��������� � ��������</param>
        public void ActivateSpeedBoost(float duration)
        {
            m_SpeedBoostDuration = duration;
            m_SpeedBoostEndTime = Time.time + duration;
        }

        public void IndestructbleBoost(float duration)
        {
            m_IndestructibleBoostDuration = duration;
            m_IndestructibleBoostEndTime = Time.time + duration;
            ActiveIndestructible(1);
            m_Shield.SetActive(true);
            
        }*/

        public void Use(EnemyAsset asset)
        {
            m_MaxLinearVelocity = asset.m_MoveSpeed;
            base.Usee(asset);
        }

    }

}

