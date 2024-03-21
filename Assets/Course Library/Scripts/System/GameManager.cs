using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts.System
{
    public class GameManager : MonoBehaviour
    {
        [Header("Spawn Attributes")] 
        [SerializeField] private List<GameObject> targets;

        [SerializeField] private float spawnRate = 1.0f;
        private void Start()
        {
            StartCoroutine(SpawnTargets());
        }

        private IEnumerator SpawnTargets()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnRate);
                var index = GetRamdomIndex();
                Instantiate(targets[index]);
            }
        }

        private int GetRamdomIndex()
        {
            return Random.Range(0, targets.Count);
        }
    }
}