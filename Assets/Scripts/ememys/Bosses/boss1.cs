using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss1 : MonoBehaviour
{
    private Transform player;

    public static float SQHP, SQMaxHP = 25f;

    private float fireSpeed = 12;
    private float canFire = 0.05f;
    private float timer;

    public GameObject bullet;
    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SQHP = SQMaxHP;

        player = GameObject.FindGameObjectWithTag("player1").transform;
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
            Debug.Log("Yes");
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            Vector2 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedBullet, 2);
            timer = 0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            characterCube.HP -= (20 * Time.deltaTime);
        }
    }
    public void DamageDealt(float damageAmount)
    {
        SQHP -= damageAmount;

        if (SQHP <= 0)
        {
            Destroy(gameObject);
            //load scene
        }
    }
}

