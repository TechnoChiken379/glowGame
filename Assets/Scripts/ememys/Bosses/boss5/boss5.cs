using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss5 : MonoBehaviour
{
    private Transform player;

    [SerializeField] public characterCube characterCube;

    public static float MSHP, MSMaxHP = 60f;

    private float speed = 4f;
    private float closeEnough = 2f;


    // Start is called before the first frame update
    void Start()
    {
        MSHP = MSMaxHP;

        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
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
            characterCube.HP -= 10;
        }
    }
    public void DamageDealt(float damageAmount)
    {
        MSHP -= damageAmount;
        if (MSHP <= 0)
        {
            Destroy(gameObject);
            characterCube.HP = characterCube.backUpHP;
            characterCube.bossBuildIndex = 6;
            SceneManager.LoadScene("winScreen");
        }
    }
}

