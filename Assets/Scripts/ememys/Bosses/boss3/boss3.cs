using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss3 : MonoBehaviour
{
    private Transform player;

    [SerializeField] public characterCube characterCube;

    public static float TGHP, TGMaxHP = 50f;

    private float canFire = 1.5f;
    private float timer;

    public GameObject zombieGrunt;
    public Transform zombieGruntSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        TGHP = TGMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        FireGrunt();
    }

    public void FireGrunt()
    {
        if (timer >= canFire)
        {
            GruntSpawn();
            if (TGHP <= 20)
            {
                GruntSpawn();
            }
            if (TGHP <= 5)
            {
                GruntSpawn();
            }
            timer = 0f;
        }
    }

    public void GruntSpawn()
    {
        GameObject ZombieGrunt = Instantiate(zombieGrunt, zombieGruntSpawnPoint.position, Quaternion.identity);
        Vector3 directionToPlayer = (player.position - zombieGruntSpawnPoint.position).normalized;
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
        TGHP -= damageAmount;
        if (TGHP <= 0)
        {
            Destroy(gameObject);
            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 3;
            SceneManager.LoadScene("winScreen");
        }
    }
}

