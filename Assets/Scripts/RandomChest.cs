using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadomChest : MonoBehaviour
{
    public GameObject ChestPreFab;
    public float spawnInterval;


    // Update is called once per frame
    private void Start()
    {
        // Gọi phương thức SpawnChest sau mỗi khoảng thời gian spawnInterval, bắt đầu sau 0 giây
        InvokeRepeating("SpawnChest", 0.0f, spawnInterval);
    }

    void SpawnChest()
    {
        Vector2 randomSpawnPosition = new Vector2(Random.Range(-30, 30), Random.Range(-20, 20));
        Instantiate(ChestPreFab, randomSpawnPosition, Quaternion.identity);
    }
}
