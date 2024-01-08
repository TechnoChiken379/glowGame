using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss3 : MonoBehaviour
{
    private Transform player;

    public bossCheckIndicator bossCheckIndicator;

    [SerializeField] public characterCube characterCube;

    public static float TGHP, TGMaxHP = 40f;

    private float canFire = 1.3333f;
    private float timer;

    public GameObject zombieGrunt;
    public Transform zombieGruntSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        bossCheckIndicator.boss3Check = false;

        TGHP = TGMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        canFire *= controlScript.controlAttackSpeed;

        characterCube.bossBuildIndex = 3;
    }

    // Update is called once per frame
    void Update()
    {
        bossFightingTimer.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimer.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);
        bossFightingTimerInBoss.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimerInBoss.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);

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
            characterCube.HP -= 20 * controlScript.controlDamage;
        }
    }
    public void DamageDealt(float damageAmount)
    {
        TGHP -= damageAmount;
        if (TGHP <= 0)
        {
            bossCheckIndicator.boss3Check = true;

            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 4;

            winScreenChecker();
        }
    }

    void winScreenChecker()
    {
        bossCheckIndicator.boss3Check = true;
        if (bossCheckIndicator.boss3Check == true && bossCheckIndicator.allBossesDead == true)
        {
            SceneManager.LoadScene("epicWinScreen");
        }
        else if (bossCheckIndicator.boss3Check == true && bossCheckIndicator.allBossesDead == false)
        {
            SceneManager.LoadScene("winScreen");
        }
    }
}

