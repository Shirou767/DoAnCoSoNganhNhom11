using System.Collections;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject[] slimePrefabs; // Mảng chứa các Prefab quái khác nhau
    public Transform[] spawnPoints; // Danh sách điểm spawn trên bản đồ
    public Transform[] waypoints; // Waypoints cho quái di chuyển
    public float spawnInterval = 2f; // Khoảng thời gian giữa mỗi lần spawn

    void Start()
    {
        StartCoroutine(SpawnSlimeRoutine());
    }

    IEnumerator SpawnSlimeRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnSlime();
        }
    }

    void SpawnSlime()
{
    

    // Chọn ngẫu nhiên một loại quái trong danh sách slimePrefabs
    GameObject randomSlimePrefab = slimePrefabs[Random.Range(0, slimePrefabs.Length)];

    // Chọn ngẫu nhiên một điểm spawn
    Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

    // Debug để kiểm tra thông tin
    Debug.Log($"Spawn {randomSlimePrefab.name} tại {randomSpawnPoint.position}");

    // Tạo một quái từ Prefab tại điểm spawn
    GameObject spawnedSlime = Instantiate(randomSlimePrefab, randomSpawnPoint.position, Quaternion.identity);

    // Gán danh sách waypoint cho quái clone
    EnemyMovement enemyMovement = spawnedSlime.GetComponent<EnemyMovement>();
    if (enemyMovement != null)
    {
        enemyMovement.waypoints = waypoints; // Gán waypoint cho Slime clone
        enemyMovement.enabled = true; // Chỉ kích hoạt script trên clone
        Debug.Log($"{spawnedSlime.name} đã được gán waypoint!");
    }
    else
    {
        Debug.LogError("EnemyMovement script chưa có trên Prefab Slime!");
    }
}
}

