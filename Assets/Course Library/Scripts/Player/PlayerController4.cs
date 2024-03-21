using System;
using System.Collections;
using Course_Library.Scripts.ClassExtensions;
using UnityEngine;

namespace Course_Library.Scripts.Player
{
    public class PlayerController4 : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed = 5.0f;

        [Header("PowerUp Attribute")] 
        [SerializeField] private GameObject powerUpIndicator;
        [SerializeField] private float powerUpStrength = 15.0f;
        [SerializeField] private bool hasPowerUp;
        
        
        // Component references
        private Rigidbody _rigidbody;
        private GameObject _focalPoint;
        
        // Input mapping
        private static float ForwardInput => Input.GetAxis("Vertical");
        
        // Start is called before the first frame update
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _focalPoint = GameObject.Find("FocalPoint");
        }

        // Update is called once per frame
        private void Update()
        {
            MoveForward();
            StationPowerIndicator();
        }

        private void MoveForward()
        {
            _rigidbody.AddForce(_focalPoint.transform.forward * (speed * ForwardInput));
        }

        private void StationPowerIndicator()
        {
            powerUpIndicator.transform.position = transform.position.Add(y: -0.5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            PowerUp(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            DetectEnemy(other);
        }

        private void PowerUp(Collider powerUp)
        {
            if (powerUp.CompareTag("PowerUp"))
            {
                hasPowerUp = true;
                powerUpIndicator.SetActive(true);
                Destroy(powerUp.gameObject);
                StartCoroutine(PowerUpCountdownRoutine());
            }
        }

        private IEnumerator PowerUpCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            powerUpIndicator.SetActive(false);
            hasPowerUp = false;
        }

        private void DetectEnemy(Collision enemy)
        {
            if (enemy.gameObject.CompareTag("Enemy") && hasPowerUp)
            {
                var enemyRig = enemy.gameObject.GetComponent<Rigidbody>();
                var pushDirection = enemy.gameObject.transform.position - transform.position;
                enemyRig.AddForce(pushDirection * powerUpStrength, ForceMode.Impulse);
                Debug.Log($"Collided with {enemy.gameObject.name} with powerup set to {hasPowerUp}");
            }
        }
        
    }
}
