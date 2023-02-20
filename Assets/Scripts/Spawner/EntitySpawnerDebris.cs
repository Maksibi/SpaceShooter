using UnityEngine;

namespace SpaceShooter
{
    public class EntitySpawnerDebris : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Destructible[] debrisPrefabs;

        [SerializeField] private int debrisCount;

        [SerializeField] private CircleArea circleArea;

        [SerializeField] private float randomSpeed;
        #endregion

        private void Start()
        {
            for (int i = 0; i < debrisCount; i++) SpawnDebris();
        }
        private void SpawnDebris()
        {
            int index = Random.Range(0, debrisPrefabs.Length);

            GameObject debris = Instantiate(debrisPrefabs[index].gameObject);

            debris.transform.position = circleArea.GetRandomInsideArea();
            debris.GetComponent<Destructible>().EventOnDeath.AddListener(OnDebrisDestroy);

            Rigidbody2D rigidbody = debris.GetComponent<Rigidbody2D>();

            if (rigidbody != null && randomSpeed > 0) rigidbody.velocity =(Vector2) UnityEngine.Random.insideUnitSphere * randomSpeed;
        }
        private void OnDebrisDestroy()
        {
            SpawnDebris();
        }
    }
}