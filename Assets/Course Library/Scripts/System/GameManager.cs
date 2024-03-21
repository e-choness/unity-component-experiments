using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

        private float _score;
        private void Start()
        {
            StartCoroutine(SpawnTargets());
            UpdateScore(0);
        }

        private IEnumerator SpawnTargets()
        {
            while (true)
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
    }
}