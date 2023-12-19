using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss2 : MonoBehaviour
{
    private Transform player;

    public static float IBHP, IBMaxHP = 60f;

    private float canTeleport = 5f;
    private float timer;

    private float speed = 4.5f;

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
    }

    public void Move()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
    }

    public void Teleport()
    {

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
            SceneManager.LoadScene("LEVELS");
        }
    }
}

