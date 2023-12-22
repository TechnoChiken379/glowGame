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

    [SerializeField] public characterCube characterCube;

    public static float RicardoHP, RicardoMaxHP = 100f;

    private float speed = 12f;
    private float closeEnough = 2f;

    public GameObject normal;
    public GameObject rage;

    private float moveTimer;
    private float canMove = 3f;
    private float startRaging = 2f;
    private float stopRaging = 1f;

    private float xPosition;
    private float yPosition;

    private bool hitwall = false;

    // Start is called before the first frame update
    void Start()
    {
        RicardoHP = RicardoMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        normal.SetActive(true);
        rage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= stopRaging)
        {
            normal.SetActive(true);
            rage.SetActive(false);
        }
        if (moveTimer >= startRaging)
        {
            normal.SetActive(false);
            rage.SetActive(true);
        }
        Move();
    }

    public void Move()
    {
        if (hitwall == false)
        {
            transform.Translate(new Vector3(xPosition, yPosition, 0).normalized * Time.deltaTime * speed);
        }
        if (moveTimer >= canMove)
        {
            hitwall = false;
            xPosition = player.position.x; 
            yPosition = player.position.y;
            moveTimer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            characterCube.HP -= 10;
        }

        if (collision.gameObject.CompareTag("border"))
        {
            hitwall = true;
            xPosition = player.position.x;
            yPosition = player.position.y;
            transform.Translate(new Vector3(xPosition, yPosition, 0).normalized * Time.deltaTime * speed);
        }
    }
    public void DamageDealt(float damageAmount)
    {
        RicardoHP -= damageAmount;
        if (RicardoHP <= 0)
        {
            Destroy(gameObject);
            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 6;
            SceneManager.LoadScene("winScreen");
        }
    }
}

