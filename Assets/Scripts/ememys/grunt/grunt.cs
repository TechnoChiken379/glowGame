using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grunt : MonoBehaviour
{
    public GameObject player;
    private Transform characterCubePosition;
    public float gruntXPosition = 8.6f;
    public float gruntYPosition = 4.7f;

    private float gruntSpeed = 4f;
    public static float gruntHP, gruntMaxHP = 4f;

    // Start is called before the first frame update
    void Start()
    {

        var SP = Random.Range(0, 8);
        if (SP == 0)
        {
            gruntXPosition = -10.6f;
            gruntYPosition = 6.7f;
            transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        } else if (SP == 1)
        {
            gruntXPosition = 0f;
            gruntYPosition = 6.7f;
            transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        } else if (SP == 2)
        {
            gruntXPosition = 10.6f;
            gruntYPosition = 6.7f;
            transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        } else if (SP == 3)
        {
            gruntXPosition = -10.6f;
            gruntYPosition = 0f;
            transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        } else if (SP == 4)
        {
            gruntXPosition = 10.6f;
            gruntYPosition = 0f;
            transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        } else if (SP == 5)
        {
            gruntXPosition = -10.6f;
            gruntYPosition = -6.7f;
            transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        } else if (SP == 6)
        {
            gruntXPosition = 0f;
            gruntYPosition = -6.7f;
            transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        } else if (SP == 7)
        {
            gruntXPosition = 10.6f;
            gruntYPosition = -6.7f;
            transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        }

        gruntHP = gruntMaxHP; 

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
        gruntHP -= damageAmount;

        if (gruntHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

