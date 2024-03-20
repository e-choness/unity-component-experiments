using UnityEngine;

namespace Course_Library.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Physics")]
        [SerializeField] private float jumpForce = 100.0f;

        [Header("Gravity")] 
        [SerializeField] private float gravityMultiplier = 10.0f;

        [Header("Game Over State")] [SerializeField]
        private bool gameOver;
        
        private Rigidbody _rigidbody;
    
        private bool _isGrounded = true;
    
    
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityMultiplier;
        }

        // Update is called once per frame
        void Update()
        {
            HandleJump();
        }

        void HandleJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }else if (other.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Gotcha, game over!");
            }
        }

        public bool GetGameOver()
        {
            return gameOver;
        }
    }
}
