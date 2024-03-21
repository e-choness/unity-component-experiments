using System;
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
        [SerializeField] private float maxTorgue = 10.0f;

        [Header("Position")]
        [SerializeField] private float xRange = 4.0f;
        [SerializeField] private float ySpawnPosition = -6.0f;
        
        private Rigidbody _rigidbody;

        private void Start()
        { 
            InitPhysics();
        }

        private void InitPhysics()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(RandomForce());
            _rigidbody.AddTorque(RandomTorgue(), RandomTorgue(), RandomTorgue(), ForceMode.Impulse);
            transform.position = RandomSpawnPosition();
        }

        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(minSpeed, maxSpeed);
        }

        private float RandomTorgue()
        {
            return Random.Range(-maxTorgue, maxTorgue);
        }

        private Vector3 RandomSpawnPosition()
        {
            return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition);
        }

        private void OnMouseDown()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}