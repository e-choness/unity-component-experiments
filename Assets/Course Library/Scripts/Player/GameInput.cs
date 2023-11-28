using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Course_Library.Scripts.Player
{
    public class GameInput : MonoBehaviour
    {
        [SerializeField] private StateController stateController;
        [SerializeField] private float jumpForce;
        private StateController _stateController;
        private InputAction _playerJump;
        private Rigidbody _playerRigidbody;
        private MovementState _movementState;
        private bool _isGrounded;

        private enum MovementState
        {
            Jumping,
            Grounded
        };
        
        void Awake()
        {
            TryGetComponent<StateController>(out _stateController);
            TryGetComponent<Rigidbody>(out _playerRigidbody);
            // _stateController = stateController.GetComponent<StateController>();
            
            var inputController = new InputController();
            
            _movementState = MovementState.Grounded;
            _isGrounded = true;
            _playerJump = inputController.Player.Jump;

            Physics.gravity = new Vector3(0.0f, -30.0f, 0.0f);
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
                _playerRigidbody.velocity += Vector3.up * jumpForce;
                _isGrounded = false;
            }
        }

        void OnCancelJumping(InputAction.CallbackContext context)
        {
            _playerRigidbody.velocity = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Ground")) _isGrounded = true;
        }
    }
}
