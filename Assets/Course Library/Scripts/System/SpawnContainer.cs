
using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts.System
{
    public class SpawnContainer : MonoBehaviour
    {
        [Header("Enemy")]
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int waveCount = 1;
        private int _enemyCount;

        [Header("PowerUp")]
        [SerializeField] private GameObject powerUpPrefab;

        // Spawn position properties
        private float _spawnRange = 9.0f;
        
        // Start is called before the first frame update
        private void Start()
        {
            SpawnEnemyWave(waveCount);
            SpawnPowerUp();
        }

        private void SpawnEnemyWave(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var spawnPoint = GetSpawnPoint();
                Instantiate(enemyPrefab, spawnPoint, enemyPrefab.transform.rotation);

            }
        }

        private void SpawnPowerUp()
        {
            Instantiate(powerUpPrefab, GetSpawnPoint(), powerUpPrefab.transform.rotation);
        }

        private Vector3 GetSpawnPoint()
        {
            var x = Random.Range(0.0f, _spawnRange);
            var z = Random.Range(0.0f, _spawnRange);
            return new Vector3(x, 0.0f, z);
        }

        private void Update()
        {
            RespawnEnemy();
        }

        
        private void RespawnEnemy()
        {
            _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (_enemyCount == 0)
            {
                waveCount++;
                SpawnPowerUp();
                SpawnEnemyWave(waveCount);
            }
                
        }
    }
}
