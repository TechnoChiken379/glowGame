using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss5FireBallAttack : MonoBehaviour
{
    private float timer;
    private float canFire = 3;
    private float fireSpeed = 8;

    public GameObject FireBall;
    public Transform fireBallSpawnPoint;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {


        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        FireSnipeBullet();
    }
    public void FireSnipeBullet()
    {
        if (timer >= canFire)
        {
            GameObject spawnedSnipeBullet = Instantiate(FireBall, fireBallSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - fireBallSpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * (fireSpeed * 1.5f);

            Destroy(spawnedSnipeBullet, 2);
            timer = 0f;
        }

    }

}
