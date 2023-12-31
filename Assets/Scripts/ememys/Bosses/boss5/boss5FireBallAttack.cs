using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss5FireBallAttack : MonoBehaviour
{
    private float timer;
    private float canFire = 3;
    private float fireSpeed = 10;

    public GameObject FireBall;
    public Transform fireBallSpawnPoint;

    private Transform player;

    private float closeEnough = 2.5f;

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
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer >= closeEnough)
        {
            FireSnipeBullet();
        }
    }
    public void FireSnipeBullet()
    {
        if (timer >= canFire)
        {
            GameObject spawnedSnipeBullet = Instantiate(FireBall, fireBallSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - fireBallSpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedSnipeBullet, 2);
            timer = 0f;
        }

    }

}
