using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss6ShoutAttack : MonoBehaviour
{
    private float timer;
    private float canFire = 3;
    private float fireSpeed = 10;

    public GameObject Shout1;
    public float shout1Timer;
    public float shout1MaxTimer = 4;
    public Transform Shout1SpawnPoint;

    public GameObject Shout2;
    public float shout2Timer;
    public float shout2MaxTimer = 4;
    public Transform Shout2SpawnPoint;

    private Transform player;

    private float closeEnough = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
        shout1Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (shout1Timer >= 0)
        {
            shout1Timer += Time.deltaTime;
        }
        if (shout1Timer >= 2)
        {
            shout2Timer += Time.deltaTime;
        }
        if (shout2Timer >= 2)
        {
            shout1Timer += Time.deltaTime;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (shout1Timer >= shout1MaxTimer)
        {
            Shout1SnipeBullet();
        }

        if (shout2Timer >= shout2MaxTimer)
        {
            Shout2SnipeBullet();
        }
    }
    public void Shout1SnipeBullet()
    {
        if (timer >= canFire)
        {
            GameObject spawnedSnipeBullet = Instantiate(Shout1, Shout1SpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - Shout1SpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedSnipeBullet, 2);
            shout1Timer = 0f;
        }
    }

    public void Shout2SnipeBullet()
    {
        if (timer >= canFire)
        {
            GameObject spawnedSnipeBullet = Instantiate(Shout2, Shout2SpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - Shout2SpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedSnipeBullet, 2);
            shout2Timer = 0f;
        }
    }
}
