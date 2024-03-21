using UnityEngine;

namespace Course_Library.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed = 4.0f;
        
        // Component references
        private Rigidbody _rigidbody;
        
        // Object references
        private GameObject _player;
        
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            ChasePlayer();
            Despawn();
        }
        
        private void Despawn()
        {
            if(transform.position.y < -10.0f)
                Destroy(gameObject);
        }


        private void ChasePlayer()
        {
            var lookDirection = (_player.transform.position - transform.position).normalized;
            _rigidbody.AddForce( lookDirection * speed);
        }
    }
}
