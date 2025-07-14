using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShootan
{
    public class PlayerStatistics
    {
        public int numKills;
        public int time;
        public int score;
       
        public void Reset()
        {
            numKills = 0;
            time = 0;
            score = 0;
           
        }
    }

}

