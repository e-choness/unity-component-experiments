using UnityEngine;

namespace Course_Library.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Physics")]
        [SerializeField] private float jumpForce = 100.0f;

        [Header("Gravity")] 
        [SerializeField] private float gravityMultiplier = 10.0f;
        
        [Header("Game Over State")] 
        [SerializeField] private bool gameOver;

        [Header("Visual Effects")] 
        [SerializeField] private ParticleSystem explosionParticle;
        [SerializeField] private ParticleSystem dirtParticle;

        [Header("Sound Effects")] 
        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private AudioClip crashSound;
        
        // Component references
        private Rigidbody _rigidbody;
        private Animator _animator;
        private AudioSource _audio;
    
        private bool _isGrounded = true;
        private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
        private static readonly int DeathB = Animator.StringToHash("Death_b");
        private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");


        // Start is called before the first frame update
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _audio = GetComponent<AudioSource>();
            Physics.gravity *= gravityMultiplier;
        }

        // Update is called once per frame
        private void Update()
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
                _audio.PlayOneShot(jumpSound, Random.Range(0.7f, 1.0f));
                StopDirt();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                PlayDirt();
            }else if (other.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Gotcha, game over!");
                
                // Set game over
                gameOver = true;
                
                // Stop player animation
                StopAnimation();
                
                // Play explosion particle effect
                PlayExplosion();
                
                // Play crash sound
                PlayCrashSound();
                
                // Stop dirt effect
                StopDirt();
            }
        }

        private void StopAnimation()
        {
            _animator.SetBool(DeathB, true);
            _animator.SetInteger(DeathTypeINT, 1);
        }

        private void PlayExplosion()
        {
            explosionParticle.Play();
        }

        private void PlayDirt()
        {
            dirtParticle.Play();
        }
        private void StopDirt()
        {
            dirtParticle.Stop();
        }

        private void PlayCrashSound()
        {
            _audio.PlayOneShot(crashSound, 1.0f);
        }

        public bool GetGameOver()
        {
            return gameOver;
        }
    }
}
