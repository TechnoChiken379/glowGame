using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class boss4c : MonoBehaviour
{
    private Transform player;

    [SerializeField] public characterCube characterCube;

    public static float CGHP, CGMaxHP = 25f;

    private float fireSpeed = 12;
    private float canFire = 2f;
    private float timerShotgun;
    private float speed = 2.5f;


    public GameObject bullet;

    public Transform bulletSpawnPoint;

    private float xMax = 8.1f;
    private float yMax = 4.2f;

    private float xMin = -8.1f;
    private float yMin = -4.2f;

    public float xPosition;
    public float yPosition;

    private float chooseNewPosition = 2f;
    private float moveTimer;

    float numberOfPellets = 5f;
    float spreadAngle = 30f;

    // Start is called before the first frame update
    void Start()
    {
        CGHP = CGMaxHP;
        moveTimer = 15;
        timerShotgun = 1f;
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        canFire *= controlScript.controlAttackSpeed;
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
        timerShotgun += Time.deltaTime;
        moveTimer += Time.deltaTime;

        Move();
        FireShotgunBullet();
    }
    public void FireShotgunBullet()
    {
        if (timerShotgun >= canFire)
        {
            for (int i = 0; i < numberOfPellets; i++)
            {
                Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(-spreadAngle / 2f, spreadAngle / 2f));

                Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
                Vector3 spreadDirection = randomRotation * directionToPlayer;

                GameObject spawnedPellet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
                spawnedPellet.GetComponent<Rigidbody2D>().velocity = spreadDirection * fireSpeed;

                Destroy(spawnedPellet, 0.5f);
            }

            timerShotgun = 0f;
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

