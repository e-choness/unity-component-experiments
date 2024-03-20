using Course_Library.Scripts.Player;
using UnityEngine;

namespace Course_Library.Scripts.System
{
    public class SpawnManager : MonoBehaviour
    {
        [Header("Obstacles")]
        [SerializeField] private GameObject obstaclePrefab;

        [Header("Spawn Time")] 
        [SerializeField] private float startDelay = 2.0f;
        [SerializeField] private float spawnTime = 2.0f;
    
        // Spawn Positions
        private Vector3 _spawnPosition = new(30.0f, 0.0f, 0.0f);

        // Obstacle object
        private GameObject _obstacle;
        
        // Player Controller
        private PlayerController _player;

        private void Start()
        {
            _player = FindAnyObjectByType<PlayerController>();
            InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnTime);
            
        }

        private void Update()
        {
            CancelSpawn();
        }

        private GameObject SpawnObstacle()
        {
            return Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
        }

        private void CancelSpawn()
        {
            if (_player.GetGameOver())
            {
                CancelInvoke(nameof(SpawnObstacle));
            }
        }
    }
}
