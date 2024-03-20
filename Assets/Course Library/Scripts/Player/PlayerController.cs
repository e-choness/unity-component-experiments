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
        
        // Component references
        private Rigidbody _rigidbody;
        private Animator _animator;
    
        private bool _isGrounded = true;
        private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
        private static readonly int DeathB = Animator.StringToHash("Death_b");
        private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");


        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            Physics.gravity *= gravityMultiplier;
        }

        // Update is called once per frame
        void Update()
        {
            HandleJump();
        }

        void HandleJump()
        {
            if (gameOver) return;
            
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                _isGrounded = false;
                _animator.SetTrigger(JumpTrig);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }else if (other.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Gotcha, game over!");
                
                // Set game over
                gameOver = true;
                
                // Stop player animation
                StopAnimation();
            }
        }

        private void StopAnimation()
        {
            _animator.SetBool(DeathB, true);
            _animator.SetInteger(DeathTypeINT, 1);
        }

        public bool GetGameOver()
        {
            return gameOver;
        }
    }
}
