using UnityEngine;

namespace SpaceShootan
{
    /// <summary>
    /// Базовый класс для всех итерактивных объектов на сцена
    /// </summary>
    public abstract class Entity : MonoBehaviour
    {
        /// <summary>
        /// Название объкта для пользователя
        /// </summary>
        [SerializeField]
        private string m_Nickname;
        public string Nickname => m_Nickname;
    }
}
