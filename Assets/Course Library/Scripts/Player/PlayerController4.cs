using UnityEngine;

namespace Course_Library.Scripts.Player
{
    public class PlayerController4 : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed = 5.0f;
        
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
        }

        private void MoveForward()
        {
            _rigidbody.AddForce(_focalPoint.transform.forward * (speed * ForwardInput));
        }
    }
}
