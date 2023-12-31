using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss1 : MonoBehaviour
{
    private Transform player;

    public bossCheckIndicator bossCheckIndicator;

    [SerializeField] public characterCube characterCube;

    public static float SQHP, SQMaxHP = 50f;

    private float fireSpeed = 8;
    private float canFire = 0.1f;
    private float canFireSnipe = 4f;
    private float timer;
    private float timerSnipe = 0f;

    public GameObject bullet;
    public GameObject snipeBullet;

    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        bossCheckIndicator.boss1Check = false;

        SQHP = SQMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        canFire *= controlScript.controlAttackSpeed;
        canFireSnipe *= controlScript.controlAttackSpeed;

        characterCube.bossBuildIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bossFightingTimer.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimer.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);
        bossFightingTimerInBoss.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimerInBoss.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);

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
            characterCube.HP -= 20 * controlScript.controlDamage;
        }
    }
    public void DamageDealt(float damageAmount)
    {
        SQHP -= damageAmount;
        if (SQHP <= 0)
        {
            bossCheckIndicator.boss1Check = true;

            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 2;

            winScreenChecker();
        }
    }

    void winScreenChecker()
    {
        bossCheckIndicator.boss1Check = true;
        if (bossCheckIndicator.boss1Check == true && bossCheckIndicator.boss2Check == true && bossCheckIndicator.boss3Check == true && bossCheckIndicator.boss4Check == true && bossCheckIndicator.boss5Check == true && bossCheckIndicator.boss6Check == true)
        {
            bossCheckIndicator.allBossesDead = true;
        }
        else bossCheckIndicator.allBossesDead = false;
        if (bossCheckIndicator.boss1Check == true && bossCheckIndicator.allBossesDead == true)
        {
            SceneManager.LoadScene("epicWinScreen");
        }
        else if (bossCheckIndicator.boss1Check == true && bossCheckIndicator.allBossesDead == false)
        {
            SceneManager.LoadScene("winScreen");
        }
    }
}

