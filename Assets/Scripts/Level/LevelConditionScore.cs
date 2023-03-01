using UnityEngine;

namespace SpaceShooter
{
public class LevelConditionScore : MonoBehaviour, ILevelCondition
{
        [SerializeField] private int score;

        private bool isReached;

        bool ILevelCondition.IsCompleted
        {
            get
            {
                if(Player.Instance != null & Player.Instance.ActiveShip != null)
                {
                    if (Player.Instance.Score >= score) isReached = true;
                }
                return isReached; 
            }
        }
}
}