using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss4 : MonoBehaviour
{
    private Transform player;
    private Transform enemy;

    [SerializeField] public characterCube characterCube;

    public static float CGHP, CGMaxHP = 25f;

    private float fireSpeed = 10;
    private float canFire = 0.5f;
    private float timer;
    private float timerSnipe;
    private float canFireSnipe = 3f;
    private float speed = 3f;

    private float range = 5f;
    private float enemyRange = 3f;

    public GameObject bullet;
    public GameObject snipeBullet;

    public Transform bulletSpawnPoint;

    public float minX = -5f;  // Minimum X coordinate for the border
    public float maxX = 5f;   // Maximum X coordinate for the border
    public float minY = -5f;  // Minimum Y coordinate for the border
    public float maxY = 5f;   // Maximum Y coordinate for the border

    // Start is called before the first frame update
    void Start()
    {
        CGHP = CGMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
        enemy = GameObject.FindGameObjectWithTag("Celestial Guardian").transform;
    }
    public void Move()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        float distanceToEnemy = Vector2.Distance(transform.position, enemy.position);
        if (distanceToPlayer >= range || distanceToEnemy >= enemyRange)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerSnipe += Time.deltaTime;

        Move();
        FireBullet();
        FireSnipeBullet();
    }
    public void FireBullet()
    {
        if (timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedBullet, 2);
            timer = 0f;
        }

    }

    public void FireSnipeBullet()
    {
        if (timerSnipe >= canFireSnipe)
        {
            GameObject spawnedSnipeBullet = Instantiate(snipeBullet, bulletSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
            spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * (fireSpeed * 1.5f);

            Destroy(spawnedSnipeBullet, 2);
            timerSnipe = 0f;
        }

    }

    public void DamageDealt(float damageAmount)
    {
        CGHP -= damageAmount;
        if (CGHP <= 0)
        {
            Destroy(gameObject);
            characterCube.HP = characterCube.backUpHP;
            SceneManager.LoadScene("LEVELS");
        }
    }
}

