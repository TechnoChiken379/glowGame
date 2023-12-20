using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class boss4a : MonoBehaviour
{
    private Transform player;

    [SerializeField] public characterCube characterCube;

    public static float CGHP, CGMaxHP = 25f;

    //private float fireSpeed = 10;
    //private float canFire = 0.5f;
    //private float timer;
    //private float timerSnipe;
    //private float canFireSnipe = 3f;
    private float speed = 2.5f;


    public GameObject bullet;
    public GameObject snipeBullet;

    public Transform bulletSpawnPoint;

    private float xMax = 8.1f;
    private float yMax = 4.2f;

    private float xMin = -8.1f;
    private float yMin = -4.2f;

    public float xPosition;
    public float yPosition;

    private float chooseNewPosition = 2f;
    private float moveTimer;


    // Start is called before the first frame update
    void Start()
    {
        CGHP = CGMaxHP;
        moveTimer = 10;
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }
    public void Move()
    { 
        transform.Translate(new Vector3(xPosition, yPosition, 0).normalized * Time.deltaTime * speed);
        if (moveTimer >= chooseNewPosition)
        {
            xPosition = Random.Range(xMin, xMax);
            yPosition = Random.Range(yMin, yMax);
            moveTimer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //timerSnipe += Time.deltaTime;
        moveTimer += Time.deltaTime;

        Move();
        //FireBullet();
        //FireSnipeBullet();
    }
    //public void FireBullet()
    //{
    //    if (timer >= canFire)
    //    {
    //        GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

    //        Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
    //        spawnedBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * fireSpeed;

    //        Destroy(spawnedBullet, 2);
    //        timer = 0f;
    //    }

    //}

    //public void FireSnipeBullet()
    //{
    //    if (timerSnipe >= canFireSnipe)
    //    {
    //        GameObject spawnedSnipeBullet = Instantiate(snipeBullet, bulletSpawnPoint.position, Quaternion.identity);

    //        Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
    //        spawnedSnipeBullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * (fireSpeed * 1.5f);

    //        Destroy(spawnedSnipeBullet, 2);
    //        timerSnipe = 0f;
    //    }

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            xPosition = Random.Range(xMin, xMax);
            yPosition = Random.Range(yMin, yMax);
            moveTimer = 0;
        }
    }

    public void DamageDealt(float damageAmount)
    {
        CGHP -= damageAmount;
        if (CGHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

