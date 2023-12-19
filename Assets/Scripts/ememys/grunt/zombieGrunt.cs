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

    private float gruntSpeed = 5f;
    public static float zombieGruntHP, zombieGruntMaxHP = 4f;

    // Start is called before the first frame update
    void Start()
    {

        var SP = Random.Range(0, 8);
        if (SP == 0)
        {
            gruntXPosition = -1f;
            gruntYPosition = 1f;
            zombieGruntSpawnPoint.transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }
        else if (SP == 1)
        {
            gruntXPosition = -1f;
            gruntYPosition = 0f;
            zombieGruntSpawnPoint.transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }
        else if (SP == 2)
        {
            gruntXPosition = -1f;
            gruntYPosition = -1f;
            zombieGruntSpawnPoint.transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }
        else if (SP == 3)
        {
            gruntXPosition = -1f;
            gruntYPosition = 2f;
            zombieGruntSpawnPoint.transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }
        else if (SP == 4)
        {
            gruntXPosition = -1f;
            gruntYPosition = -2f;
            zombieGruntSpawnPoint.transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }
        else if (SP == 5)
        {
            gruntXPosition = -2f;
            gruntYPosition = 0f;
            zombieGruntSpawnPoint.transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }
        else if (SP == 6)
        {
            gruntXPosition = -2f;
            gruntYPosition = 1f;
            zombieGruntSpawnPoint.transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }
        else if (SP == 7)
        {
            gruntXPosition = -2f;
            gruntYPosition = -1f;
            zombieGruntSpawnPoint.transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }

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
            Debug.Log("Obstacle detected!");
            characterCube.HP -= 10;
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

