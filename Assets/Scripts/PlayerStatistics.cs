using UnityEngine;

namespace SpaceShooter
{
    public class PlayerStatistics : MonoBehaviour
    {
        public int numKills, score, time;

        public void Reset()
        {
            numKills = 0;
            score = 0;
            time = 0;
        }
    }
}