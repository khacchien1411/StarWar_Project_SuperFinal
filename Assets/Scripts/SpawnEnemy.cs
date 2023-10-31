using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float maxTime;
    float timer;
    public void Update()
    {
        if (timer > maxTime)
        {
            GameObject tmp = Instantiate(enemy, transform.position, Quaternion.identity);
            timer = 0;

        }
        timer += Time.deltaTime;
    }
}
