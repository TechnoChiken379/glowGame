using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss1 : MonoBehaviour
{
    private Transform player;

    [SerializeField] public characterCube characterCube;

    public static float SQHP, SQMaxHP = 50f;

    private float fireSpeed = 8;
    private float canFire = 0.1f;
    private float canFireSnipe = 4f;
    private float timer;
    private float timerSnipe;

    public GameObject bullet;
    public GameObject snipeBullet;

    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SQHP = SQMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerSnipe += Time.deltaTime;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            characterCube.HP -= 20;
        }
    }
    public void DamageDealt(float damageAmount)
    {
        SQHP -= damageAmount;
        if (SQHP <= 0)
        {
            Destroy(gameObject);
            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 2;
            SceneManager.LoadScene("winScreen");
        }
    }
}

