using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts.System
{
    public class GameManager : MonoBehaviour
    {
        [Header("Spawn Attributes")] 
        [SerializeField] private List<GameObject> targets;
        [SerializeField] private float spawnRate = 1.0f;

        [Header("UI Attributes")] 
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Button restartButton;

        // Game status
        private float _score;
        public bool IsOver { get; private set; }
        private void Start()
        {
            StartCoroutine(SpawnTargets());
            restartButton.onClick.AddListener(RestartGame);
            UpdateScore(0);
            IsOver = false;
        }

        private IEnumerator SpawnTargets()
        {
            while (!IsOver)
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
            if (GameOver())
            {
                pauseMenu.SetActive(true);
                return;
            }
        }

        private bool GameOver()
        {
            if (_score < 0)
            {
                
                return IsOver = true;
            }
            return IsOver = false;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}