using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class boss6 : MonoBehaviour
{
    private Transform player;

    public bossCheckIndicator bossCheckIndicator;

    [SerializeField] public characterCube characterCube;

    public static float RicardoHP, RicardoMaxHP = 75f;

    private float speed = 5f;

    public GameObject normal;
    public GameObject rage;

    private float moveTimer;
    private float canMoveMin = 2f;
    private float canMoveMax = 4f;
    private float waitToMove = 5f;
    private float startRaging = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        bossCheckIndicator.boss6Check = false;

        RicardoHP = RicardoMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        normal.SetActive(true);
        rage.SetActive(false);

        characterCube.bossBuildIndex = 6;
    }

    // Update is called once per frame
    void Update()
    {
        bossFightingTimer.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimer.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);
        bossFightingTimerInBoss.bossFightingTimerFLOAT += Time.deltaTime;
        bossFightingTimerInBoss.bossFightingTimerINT = Mathf.FloorToInt(bossFightingTimer.bossFightingTimerFLOAT);

        moveTimer += Time.deltaTime;
        if (moveTimer >= startRaging)
        {
            normal.SetActive(false);
            rage.SetActive(true);
        }
        Move();
    }

    public void Move()
    {
        if (moveTimer >= canMoveMin && moveTimer <= canMoveMax)
        {
            transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
        }
        if (moveTimer > canMoveMax)
        {
            normal.SetActive(true);
            rage.SetActive(false);
        }
        if (moveTimer >= waitToMove)
        {
            moveTimer = 0;
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
        RicardoHP -= damageAmount;
        if (RicardoHP <= 0)
        {
            bossCheckIndicator.boss6Check = true;

            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 6;

            winScreenChecker();
        }
    }

    void winScreenChecker()
    {
        bossCheckIndicator.boss6Check = true;
        if (bossCheckIndicator.boss1Check == true && bossCheckIndicator.boss2Check == true && bossCheckIndicator.boss3Check == true && bossCheckIndicator.boss4Check == true && bossCheckIndicator.boss5Check == true && bossCheckIndicator.boss6Check == true)
        {
            bossCheckIndicator.allBossesDead = true;
        }
        else bossCheckIndicator.allBossesDead = false;
        if (bossCheckIndicator.boss6Check == true && bossCheckIndicator.allBossesDead == true)
        {
            SceneManager.LoadScene("epicWinScreen");
        }
        else if (bossCheckIndicator.boss6Check == true && bossCheckIndicator.allBossesDead == false)
        {
            SceneManager.LoadScene("winScreen");
        }
    }
}

