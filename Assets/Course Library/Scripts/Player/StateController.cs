using UnityEngine;
using UnityEngine.Serialization;

namespace Course_Library.Scripts.Player
{
    public class StateController : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform playerPosition;
        private GameObject _player;
        
        private StateBase<GameObject> currentState;

        public void SetState(StateBase<GameObject> state)
        {
            currentState = state;
            StartCoroutine(currentState.Start(_player));
        }

        public void OnPlayerJump()
        {
            StartCoroutine(currentState.Jumping(_player));
        }

        public void OnPlayerRunning()
        {
            StartCoroutine(currentState.Running(_player));
        }

        private void Start()
        {
            SetupScene();
        }

        private void SetupScene()
        {
            // var player = Instantiate(this.playerPrefab, playerPosition);
            
            // SetState(new PlayerState(this));
        }
    }
}
