using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPosition;

    public float timeBetweenWaves;
    private float spawnCountdown = 2f;

    private int waveNumber = 1;

    public TextMeshProUGUI timerCountdown;

    private void Update()
    {
        if(spawnCountdown <=0f)
        {
            StartCoroutine(SpawnWave());
            
            spawnCountdown = UnityEngine.Random.Range(4f, 8f);
        }

        spawnCountdown -= Time.deltaTime;
        timerCountdown.text = Mathf.Round(spawnCountdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.2f, 0.7f));
        }
        waveNumber++;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
    }
}
