using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss1 : MonoBehaviour
{
    private Transform player;

    public static float SQHP, SQMaxHP = 25f;

    private float fireSpeed = 12;
    private float canFire = 0.1f;
    private float timer;

    public GameObject bullet;
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
        FireBullet();
        
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
        Debug.Log(SQHP);
        if (SQHP <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LEVELS");
        }
    }
}

