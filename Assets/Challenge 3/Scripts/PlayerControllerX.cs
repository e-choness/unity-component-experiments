using UnityEngine;

namespace Challenge_3.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        public bool gameOver;

        [Header("Physics")]
        public float floatForce;

        [SerializeField] private float bounceForce = 500.0f;
    
        private float gravityModifier = 1.5f;
        private Rigidbody playerRb;

        [Header("Visual Effects")]
        public ParticleSystem explosionParticle;
        public ParticleSystem fireworksParticle;

        [Header("Sound Effects")]
        private AudioSource playerAudio;
        public AudioClip moneySound;
        public AudioClip explodeSound;


        // Start is called before the first frame update
        void Start()
        {
            Physics.gravity *= gravityModifier;
            playerRb = GetComponent<Rigidbody>();
            playerAudio = GetComponent<AudioSource>();

            // Apply a small upward force at the start of the game
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        }

        // Update is called once per frame
        void Update()
        {
            if (gameOver)
            {
                playerRb.constraints = RigidbodyConstraints.FreezePosition;
                return;
            }
        
            FloatUp();
        }

        private void FloatUp()
        {
            // While space is pressed and player is low enough, float up
            if (Input.GetKey(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * floatForce);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            // if player collides with bomb, explode and set gameOver to true
            if (other.gameObject.CompareTag("Bomb"))
            {
                explosionParticle.Play();
                playerAudio.PlayOneShot(explodeSound, 1.0f);
                gameOver = true;
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
            } 

            // if player collides with money, fireworks
            else if (other.gameObject.CompareTag("Money"))
            {
                fireworksParticle.Play();
                playerAudio.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);

            }

            else if(other.gameObject.CompareTag("Ground"))
            {
                playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }

        }

    }
}
