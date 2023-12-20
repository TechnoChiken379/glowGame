using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss4 : MonoBehaviour
{
    private Transform player;

    [SerializeField] public characterCube characterCube;

    public static float CGHP, CGMaxHP = 25f;

    private float fireSpeed = 10;
    private float canFire = 0.5f;
    private float timer;
    private float timerSnipe;
    private float canFireSnipe = 3f;
    private float speed = 3f;

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
    }
    public void Move()
    {
        // Generate a random destination within the specified boundaries
        Vector2 randomDestination = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Calculate the movement direction
        Vector2 movementDirection = (randomDestination - (Vector2)transform.position).normalized;

        // Calculate the new position based on time, speed, and direction
        Vector2 newPosition = (Vector2)transform.position + movementDirection * Time.deltaTime * speed;

        // Clamp the new position within the defined border
        float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);

        // Set the new position
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
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

