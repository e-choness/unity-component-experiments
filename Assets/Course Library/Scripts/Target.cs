using Course_Library.Scripts.System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts
{
    public class Target : MonoBehaviour
    {
        [Header("Speed")]
        [SerializeField] private float minSpeed = 12.0f;
        [SerializeField] private float maxSpeed = 16.0f;
        
        [Header("Torgue")]
        [SerializeField] private float maxTorque = 10.0f;

        [Header("Position")]
        [SerializeField] private float xRange = 4.0f;
        [SerializeField] private float ySpawnPosition = -6.0f;

        [Header("Score")]
        [SerializeField] private float score = 5.0f;
        [SerializeField] private float missPenalty = -10.0f;

        [Header("Visual Effects")]
        [SerializeField] private ParticleSystem explosionParticle;
        
        private Rigidbody _rigidbody;
        private GameManager _gameManager;

        private void Start()
        { 
            InitPhysics();
            _gameManager = FindAnyObjectByType<GameManager>();
        }

        private void InitPhysics()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(RandomForce());
            _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            transform.position = RandomSpawnPosition();
        }

        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(minSpeed, maxSpeed);
        }

        private float RandomTorque()
        {
            return Random.Range(-maxTorque, maxTorque);
        }

        private Vector3 RandomSpawnPosition()
        {
            return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition);
        }

        private void OnMouseDown()
        {
            _gameManager.UpdateScore(score);
            if (_gameManager.GameState == State.Over) return;
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            _gameManager.UpdateScore(missPenalty);
            Destroy(gameObject);
        }
    }
}