using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private Transform[] spawnPoints;

    private int waveNumber = 1;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SetWave(waveNumber);
            }

            int enemiesToSpawn = Fibonacci(waveNumber);
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            waveNumber++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs.Count == 0 || spawnPoints.Length == 0) return;

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    private int Fibonacci(int n)
    {
        if (n <= 1) return 1;
        int a = 1, b = 1, c = 1;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}