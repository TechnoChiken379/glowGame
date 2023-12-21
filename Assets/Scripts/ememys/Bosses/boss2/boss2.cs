using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss2 : MonoBehaviour
{
    private Transform player;

    [SerializeField] public characterCube characterCube;

    public static float IBHP, IBMaxHP = 60f;

    private float canTeleport = 4f;
    private float timer;

    private float speed = 4f;
    private float LROrUD;
    private float UOrD;
    private float LOrR;
    private float shiftLR;
    private float shiftUD;

    // Start is called before the first frame update
    void Start()
    {
        IBHP = IBMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Move();
        if (timer >= canTeleport)
        {
            shiftLR = 0;
            shiftUD = 0;
            Teleport();
            timer = 0;
        }
    }

    public void Move()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
    }

    public void Teleport()
    {
        LROrUD = Random.Range(0, 2);
        if (LROrUD == 0)
        {
            LOrR = Random.Range(0, 2);
            UOrD = 0f;
            if (LOrR == 0)
            {
                shiftLR = -2.5f;
            }
            else if (LOrR == 1)
            {
                shiftLR = 2.5f;
            }
        }
        if (LROrUD == 1)
        {
            UOrD = Random.Range(0, 2);
            LOrR = 0f;
            if (UOrD == 0)
            {
                shiftUD = -2.5f;
            }
            else if (UOrD == 1)
            {
                shiftUD = 2.5f;
            }
        }
        transform.position = new Vector3((player.position.x + shiftLR), (player.position.y + shiftUD), 0f);
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
        IBHP -= damageAmount;
        if (IBHP <= 0)
        {
            Destroy(gameObject);
            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 2;
            SceneManager.LoadScene("winScreen");
        }
    }
}

