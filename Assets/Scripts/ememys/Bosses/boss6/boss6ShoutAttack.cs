using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss6ShoutAttack : MonoBehaviour
{
    private float timer;
    private float canFire = 3;
    private float fireSpeed = 10;

    public GameObject Shout1;
    public float shoutTimer;
    public float shout1MaxTimer = 2;
    public Transform Shout1SpawnPoint;

    public GameObject Shout2;
    public float shout2MaxTimer = 4;
    public Transform Shout2SpawnPoint;

    private Transform player;

    private float closeEnough = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
        shoutTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        shoutTimer += Time.deltaTime;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (shoutTimer >= shout1MaxTimer)
        {
            Shout1SnipeBullet();
        }

        if (shoutTimer >= shout2MaxTimer)
        {
            Shout2SnipeBullet();
            shoutTimer = 0;
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
        }
    }
}
