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

    private float fireSpeed = 8;
    private float timerSnipe;
    private float canFireSnipe = 3.5f;
    private float speed = 2.5f;


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

        canFireSnipe *= controlScript.controlAttackSpeed;

        characterCube.bossBuildIndex = 4;
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
        timerSnipe += Time.deltaTime;
        moveTimer += Time.deltaTime;

        Move();
        FireSnipeBullet();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            xPosition = Random.Range(xMin, xMax);
            yPosition = Random.Range(yMin, yMax);
            moveTimer = 0;
        }
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            characterCube.HP -= 10 * controlScript.controlDamage;
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

