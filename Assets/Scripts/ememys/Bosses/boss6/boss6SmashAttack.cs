using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss6SmashAttack : MonoBehaviour
{
    private Transform player;

    private float timer;
    private float canFire = 2;
    private float fireSpeed = 16;

    public GameObject smashFist;
    public Transform smashFistSpawnPoint;

    private float closeEnough = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= closeEnough)
        {
           FireIceBlast();
        }

    }
    public void FireIceBlast()
    {
        if (timer >= canFire)
        { 
            GameObject spawnedSnipeBullet = Instantiate(smashFist, smashFistSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - smashFistSpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedSnipeBullet, 0.4f);
            timer = 0f;
        }

    }

}
