using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss6ShoutAttack : MonoBehaviour
{
    public float shoutTimer;
    private float canFire = 3;
    private float fireSpeed = 10;

    private int oneOrTwo;

    public GameObject Shout1;
    public Transform Shout1SpawnPoint;

    public GameObject Shout2;
    public Transform Shout2SpawnPoint;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
        shoutTimer = 0;

        canFire *= controlScript.controlAttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        shoutTimer += Time.deltaTime;

        if (shoutTimer > canFire)
        {
            oneOrTwo = Random.RandomRange(0, 2);
            if (oneOrTwo == 0)
            {
                Shout1SnipeBullet();
            }
            if (oneOrTwo == 1)
            {
                Shout2SnipeBullet();
            }
            shoutTimer = 0f;
        }
    }
    public void Shout1SnipeBullet()
    {
            GameObject spawnedSnipeBullet = Instantiate(Shout1, Shout1SpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - Shout1SpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedSnipeBullet, 2);
    }

    public void Shout2SnipeBullet()
    {
            GameObject spawnedSnipeBullet = Instantiate(Shout2, Shout2SpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - Shout2SpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedSnipeBullet, 2);
    }
}
