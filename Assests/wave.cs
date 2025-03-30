using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemySpawnData> enemies; // Danh sách quái trong wave
        public float spawnInterval; // Thời gian giữa mỗi lần spawn quái
    }

    [System.Serializable]
    public class EnemySpawnData
    {
        public GameObject enemyPrefab; // Prefab quái
        public int count; // Số lượng quái trong wave
    }

    public List<Wave> waves; // Danh sách wave theo map
    public Transform spawnPoint; // Vị trí spawn quái
    public float timeBetweenWaves = 5f; // Thời gian nghỉ giữa các wave

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        if (currentWaveIndex < waves.Count)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            Wave currentWave = waves[currentWaveIndex];
            StartCoroutine(SpawnWave(currentWave));
        }
        else
        {
            Debug.Log("Tất cả wave đã hoàn thành! Kiểm tra điều kiện chiến thắng.");
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        isSpawning = true;
        foreach (var enemyData in wave.enemies)
        {
            for (int i = 0; i < enemyData.count; i++)
            {
                Instantiate(enemyData.enemyPrefab, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(wave.spawnInterval);
            }
        }
        isSpawning = false;
        currentWaveIndex++;
        StartCoroutine(StartNextWave());
    }
}
