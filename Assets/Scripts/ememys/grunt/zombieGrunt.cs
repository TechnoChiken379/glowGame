using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zombieGrunt : MonoBehaviour
{
    public GameObject player;
    private Transform characterCubePosition;
    public Transform zombieGruntSpawnPoint;
    public float gruntXPosition = -1;
    public float gruntYPosition = 0f;

    private float gruntSpeed = 4.25f;
    public static float zombieGruntHP, zombieGruntMaxHP = 1f;

    // Start is called before the first frame update
    void Start()
    {
        var SP = Random.Range(0, 8);

        zombieGruntHP = zombieGruntMaxHP;

        characterCubePosition = GameObject.FindGameObjectWithTag("mainCharacter").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Grunt();
        
    }

    void Grunt()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, characterCubePosition.position);
        transform.Translate((characterCubePosition.position - transform.position).normalized * Time.deltaTime * gruntSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            Destroy(transform.gameObject);
            characterCube.HP -= 7;
        }
        //    if (grunt.gruntHP == 0)
        //    {
        //        Debug.Log("SecondStepWorks");
        //        Destroy(gameObject);
        //    }
    }
    public void DamageDealt(float damageAmount)
    {
        zombieGruntHP -= damageAmount;

        if (zombieGruntHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

