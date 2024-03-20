using Course_Library.Scripts.Player;
using UnityEngine;

namespace Course_Library.Scripts.Obstacle
{
    public class MoveLeft : MonoBehaviour
    {
        private float _speed = 30.0f;
        private float _leftBound = -10.0f;

        private PlayerController _player;

        private void Start()
        {
            _player = FindAnyObjectByType<PlayerController>();
        }

        // Update is called once per frame
        private void Update()
        {
            HandleGameOver();
            Despawn();
        }

        private void HandleGameOver()
        {
            if (_player.GetGameOver()) return;
            transform.Translate(Vector3.left * (Time.deltaTime * _speed));
        }

        private void Despawn()
        {
            if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}
