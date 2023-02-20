using UnityEngine;

namespace SpaceShooter
{
    public class EntitySpawner : MonoBehaviour
    {
        public enum SpawnMode
        {
            Start,
            Loop
        }
        #region Editor Fields
        [SerializeField] private Entity[] entityPrefabs;

        [SerializeField] private CircleArea area;

        [SerializeField] private SpawnMode spawnMode;

        [SerializeField] private float spawnTime;

        [SerializeField] private int spawnCount;

        [SerializeField] private AIPointControl patrolPoint;
        #endregion
        private float timer;
        #region Unity Events
        private void Start()
        {
            if (spawnMode == SpawnMode.Start) SpawnEntities();

            timer = spawnTime;
        }
        private void Update()
        {
            if (timer > 0) timer -= Time.deltaTime;

            if (spawnMode == SpawnMode.Loop & timer < 0)
            {
                SpawnEntities();

                timer = spawnTime;
            }
        }
        private void SpawnEntities()
        {
            for (int i = 0; i < spawnCount; i++)
            {
                int index = Random.Range(0, entityPrefabs.Length);

                GameObject entity = Instantiate(entityPrefabs[index].gameObject);

                entity.transform.position = area.GetRandomInsideArea();

                if (entity.TryGetComponent(out AIController aIController))
                {
                    aIController.PatrolPoint = patrolPoint;
                }
            }
        }
        #endregion
    }
}