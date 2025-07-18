using UnityEngine;
using SpaceShootan;

namespace TD
{
    public class TimeLevelCondition : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private float timeLimit = 4f;

        private void Start()
        {
            timeLimit += Time.time;
        }
        public bool IsCompleted => Time.time > timeLimit;
    }
}