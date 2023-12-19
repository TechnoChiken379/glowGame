using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class gurntSpawner : MonoBehaviour
{

    public GameObject grunt;
    private float timer;
    private float canSpawn = 10f;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= canSpawn)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        GameObject spawnedGrunt = Instantiate(grunt, transform.position, transform.rotation);
    }
}
