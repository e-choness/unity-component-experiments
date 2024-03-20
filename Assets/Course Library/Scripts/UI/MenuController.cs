using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Course_Library.Scripts.UI
{
    public class MenuController : MonoBehaviour
    {
        public MenuController instance;
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject cardToSpawn;
        [SerializeField] private Transform cardParentTransform;
        [SerializeField] private int numberOfCardsSpawn = 8;

        [HideInInspector] public List<GameObject> cards = new();

        private bool _cardsHaveSpawned;
        // private InputActionMap _uiInputMap;
        private InputAction _menuCallInput;
        private InputAction _menuCancelInput;
        private State _state = State.InGame;

        private enum State
        {
            InGame,
            InMenu
        }
        private void Awake()
        {
            if (instance == null) instance = this;
        
            canvas.SetActive(false);
            var inputController = new InputController();
            _menuCancelInput = inputController.UI.Cancel;
            _menuCallInput = inputController.Player.Menu;
        }

        private void OnEnable()
        {
            _menuCancelInput.Enable();
            _menuCallInput.Enable();
            _menuCallInput.performed += OnCallingMenu;
            _menuCancelInput.performed += OnCancelMenu;
        }

        private void OnDisable()
        {
            _menuCallInput.performed -= OnCallingMenu;
            _menuCancelInput.performed -= OnCancelMenu;
            _menuCancelInput.Disable();
            _menuCallInput.Disable();
        }

        private void OnCallingMenu(InputAction.CallbackContext context)
        {
            _state = State.InMenu;
            Debug.LogFormat("{0} - {1} calling pause menu.", nameof(MenuController), nameof(OnCallingMenu));
        
            _menuCallInput.Disable();
            _menuCancelInput.Enable();
        
            if(!_cardsHaveSpawned) SpawnCards();
        
            canvas.SetActive(true);
            Time.timeScale = 0;

        }
        private void SpawnCards()
        {
            for (int i = 0; i < numberOfCardsSpawn; i++)
            {
                var card = Instantiate(cardToSpawn, cardParentTransform);
                card.SetActive(true);
                cards.Add(card);

                if (i == 0)
                {
                    EventSystem.current.SetSelectedGameObject(card);
                }
            }

            _cardsHaveSpawned = true;
        }

        private void OnCancelMenu(InputAction.CallbackContext context)
        {
            _state = State.InGame;
            Debug.LogFormat("{0} - {1} cancelling pause menu.", nameof(MenuController), nameof(OnCancelMenu));
        
            _menuCancelInput.Disable();
            _menuCallInput.Enable();
        
            canvas.SetActive(false);
            Time.timeScale = 1;

        }
    }
}
