using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss5 : MonoBehaviour
{
    private Transform player;

    public bossCheckIndicator bossCheckIndicator;

    [SerializeField] public characterCube characterCube;

    public static float MSHP, MSMaxHP = 90f;

    private float speed = 4f;
    private float closeEnough = 2f;


    // Start is called before the first frame update
    void Start()
    {
        bossCheckIndicator.boss5Check = false;

        MSHP = MSMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        characterCube.bossBuildIndex = 5;
    }

    // Update is called once per frame
    void Update()
    {
        bossFightingTimer.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimer.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);
        bossFightingTimerInBoss.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimerInBoss.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);

        Move();
    }

    public void Move()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer >= closeEnough)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
        }
        if (distanceToPlayer <= closeEnough)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            characterCube.HP -= 10 * controlScript.controlDamage;
        }
    }
    public void DamageDealt(float damageAmount)
    {
        MSHP -= damageAmount;
        if (MSHP <= 0)
        {
            bossCheckIndicator.boss5Check = true;

            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 6;

            winScreenChecker();
        }
    }

    void winScreenChecker()
    {
        bossCheckIndicator.deafetedBossTextChecker();

        bossCheckIndicator.boss5Check = true;
        if (bossCheckIndicator.boss5Check == true && bossCheckIndicator.allBossesDead == true)
        {
            SceneManager.LoadScene("epicWinScreen");
        }
        else if (bossCheckIndicator.boss5Check == true && bossCheckIndicator.allBossesDead == false)
        {
            SceneManager.LoadScene("winScreen");
        }
    }
}

