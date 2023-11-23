using UnityEngine;
using UnityEngine.InputSystem;

namespace Course_Library.Scripts.Player
{
    public class GameInput : MonoBehaviour
    {
        [SerializeField] private GameObject stateController;
        private StateController _stateController;
        private Rigidbody _playerRigidbody;
        
        private InputAction _playerJump;
    
        void Awake()
        {
            _stateController = stateController.GetComponent<StateController>();
            
            var inputController = new InputController();
            _playerJump = inputController.Player.Jump;
        }

        private void OnEnable()
        {
            _playerJump.Enable();
            _playerJump.performed += OnJumping;

        }

        private void OnDisable()
        {
            _playerJump.performed -= OnJumping;
            _playerJump.Disable();
        }


        void OnJumping(InputAction.CallbackContext context)
        {
            _stateController.OnPlayerRunning();
        }
    }
}
