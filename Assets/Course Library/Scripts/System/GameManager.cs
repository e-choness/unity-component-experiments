using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts.System
{
    [Serializable]
    public enum State
    {
        Active,
        Pause,
        Over
    }
    public class GameManager : MonoBehaviour
    {
        [Header("Spawn Attributes")] 
        [SerializeField] private List<GameObject> targets;
        [SerializeField] private float spawnRate = 2.0f;

        [Header("Game Score")]
        [SerializeField] private TextMeshProUGUI scoreText;
        
        [Header("Pause Menu")] 
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private Button restartButton;

        [Header("Start Menu")]
        [SerializeField] private GameObject startMenu;
        [SerializeField] private List<Button> difficultyButtons;

        // Game status
        private float _score;
        [field: SerializeField] public State GameState { get; private set; } = State.Pause;
        private void Start()
        {
            InitState();
            InitStartMenu();
            InitGameOverMenu();
        }

        private void InitState()
        {
            UpdateScore(0);
        }

        private void InitStartMenu()
        {
            for(var i=0; i<difficultyButtons.Count; i++)
            {
                var i1 = i;
                difficultyButtons[i].onClick.AddListener(delegate { SetDifficulty(i1 + 1);} );
            }
        }

        private void InitGameOverMenu()
        {
            restartButton.onClick.AddListener(RestartGame);
            gameOverMenu.SetActive(false);
        }

        private IEnumerator SpawnTargets()
        {
            while (GameState == State.Active)
            {
                yield return new WaitForSeconds(spawnRate);
                var index = GetRandomIndex();
                Instantiate(targets[index]);
            }
        }

        private int GetRandomIndex()
        {
            return Random.Range(0, targets.Count);
        }

        public void UpdateScore(float scoreUpdate)
        {
            _score += scoreUpdate;
            scoreText.text = $"Score: {_score}";
        }

        private void Update()
        {
            GameOver();
        }
        
        private void GameOver()
        {
            if (_score < 0)
            {
                GameState = State.Over;
                gameOverMenu.SetActive(true);
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        private void SetDifficulty(int difficulty)
        {
            spawnRate /= difficulty;
            startMenu.SetActive(false);
            GameState = State.Active;
            StartCoroutine(SpawnTargets());
        }
    }
}