using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss5BulletAttack : MonoBehaviour
{
    private Transform player;

    private float timer;
    private float canFire = 0.6667f;
    private float fireSpeed = 8;

    public GameObject EnemyBullet;
    public Transform bulletSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        canFire *= controlScript.controlAttackSpeed;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
           FireBullet();

    }
    public void FireBullet()
    {
        if (timer >= canFire)
        { 
            GameObject spawnedSnipeBullet = Instantiate(EnemyBullet, bulletSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedSnipeBullet, 2f);
            timer = 0f;
        }

    }

}
