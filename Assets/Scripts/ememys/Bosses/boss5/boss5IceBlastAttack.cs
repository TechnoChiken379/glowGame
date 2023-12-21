using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss5IceBlastAttack : MonoBehaviour
{
    private Transform player;

    private float timer;
    private float canFire = 2;
    private float fireSpeed = 20;

    public GameObject iceBlast;
    public Transform iceBlastSpawnPoint;

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
            GameObject spawnedSnipeBullet = Instantiate(iceBlast, iceBlastSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - iceBlastSpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedSnipeBullet, 0.2f);
            timer = 0f;
        }

    }

}
