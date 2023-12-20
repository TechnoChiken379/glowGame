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
    private float closeEnough = 2.5f;

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
        MSHP -= damageAmount;
        if (MSHP <= 0)
        {
            Destroy(gameObject);
            characterCube.HP = characterCube.backUpHP;
            SceneManager.LoadScene("LEVELS");
        }
    }
}

