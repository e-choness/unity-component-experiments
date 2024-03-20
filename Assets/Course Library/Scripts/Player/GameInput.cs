using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Course_Library.Scripts.Player
{
    public class GameInput : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 100.0f;
        
        private InputAction _playerJump;
        private Rigidbody _rigidbody;

        private float lateralGravityScale => Physics.gravity.y;

        private bool _isGrounded;

        [Serializable]
        private enum MovementState
        {
            Jump,
            Grounded
        };
        
        void Awake()
        {
            TryGetComponent<Rigidbody>(out _rigidbody);
            // _stateController = stateController.GetComponent<StateController>();
            
            var inputController = new InputController();
            
            _isGrounded = true;
            _playerJump = inputController.Player.Jump;

            // Physics.gravity = new Vector3(0.0f, -30.0f, 0.0f);
        }

        private void OnEnable()
        {
            _playerJump.Enable();
            _playerJump.performed += OnJumping;
            _playerJump.canceled += OnCancelJumping;
        }

        private void OnDisable()
        {
            _playerJump.performed -= OnJumping;
            _playerJump.canceled -= OnCancelJumping;
            _playerJump.Disable();
        }


        void OnJumping(InputAction.CallbackContext context)
        {
            // _stateController.Jumping();
            if(_isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                // _rigidbody.velocity += Vector3.up * jumpForce;
                _isGrounded = false;
            }
        }

        void OnCancelJumping(InputAction.CallbackContext context)
        {
            if (_isGrounded) return;
            _rigidbody.AddForce(-transform.up * 10, ForceMode.VelocityChange);
            
            // var acceleration = Vector3.Lerp(Vector3.zero, -Vector3.up * jumpForce, 0.07f);
            // _rigidbody.AddForce(acceleration, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Ground")) _isGrounded = true;
        }
    }
}
