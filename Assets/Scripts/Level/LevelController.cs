using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public interface ILevelCondition
    {
        bool IsCompleted { get; }
    }
    public class LevelController : MonoSingleton<LevelController>
    {
        [SerializeField] private int requiredTime;
        public int RequiredTime => requiredTime;

        [SerializeField] private UnityEvent EventLevelCompleted;

        private ILevelCondition[] conditions;

        private bool IsLevelCompleted;

        private float levelTime;
        public float LevelTime => levelTime;

        private void Start()
        {
            conditions = GetComponentsInChildren<ILevelCondition>();
        }
        private void Update()
        {
            if (IsLevelCompleted == false)
            {
                levelTime += Time.deltaTime;

                CheckLevelConditions();
            }
        }
        private void CheckLevelConditions()
        {
            if (conditions == null | conditions.Length == 0) return;

            int numCompleted = 0;

            foreach(var v in conditions)
            {
                if(v.IsCompleted) numCompleted++;
            }

            if (numCompleted == conditions.Length)
            {
                IsLevelCompleted = true;
                EventLevelCompleted?.Invoke();

                LevelSequenceController.Instance?.FinishCurrentLevel(true);
            }
        }
    }
}