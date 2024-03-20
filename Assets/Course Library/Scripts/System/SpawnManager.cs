using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts.System
{
    public class SpawnManager : MonoBehaviour
    {
        [Header("Obstacles")]
        [SerializeField] private GameObject obstaclePrefab;

        [Header("Spawn Time")] 
        [SerializeField] private float startDelay = 2.0f;
        [SerializeField] private float spawnTime = 2.0f;
    
        private Vector3 _spawnPosition = new(30.0f, 0.0f, 0.0f);
        private Vector3 _despawnPosition = new(-5.0f, 0.0f, 0.0f);

        private GameObject _obstacle;

        private void Start()
        {
            
            InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnTime);
            // _obstacle = SpawnObstacle();
        }

        private void Update()
        {
            // DespawnObstacle(_obstacle);
            spawnTime = Random.Range(1.5f, 3.0f);
        }

        private GameObject SpawnObstacle()
        {
            return Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
        }

        // private void DespawnObstacle(GameObject obstacle)
        // {
        //     if (obstacle.transform.position.x < _despawnPosition.x)
        //     {
        //         Destroy(obstacle);
        //     }
        // }
    }
}
