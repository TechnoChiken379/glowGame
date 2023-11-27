using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grunt : MonoBehaviour
{
    public GameObject player;
    public float gruntXPosition;
    public float gruntYPosition;

    float maxXValue = 8.6f;
    float maxYValue = 4.7f;
    public float gruntSpeed = 2;

    public static float gruntHP, gruntMaxHP = 4f;

    // Start is called before the first frame update
    void Start()
    {
        var UOrD = Random.Range(0, 2);
        if (UOrD == 0)
        {
            gruntYPosition = Random.Range(5, 10);
        } else if (UOrD == 1)
        {
            gruntYPosition = Random.Range(-5, -10);
        }
        var lOrR = Random.Range(0, 2);
        if (lOrR == 0)
        {
            gruntXPosition = Random.Range(9, 14);
        } else if (lOrR == 1)
        {
            gruntXPosition = Random.Range(-9, -14);
        }

        gruntHP = gruntMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Grunt();
        
    }

    void Grunt()
    {
        transform.position = new Vector3(gruntXPosition, gruntYPosition, 0f);
        //bot up
        if (player.transform.position.y > transform.position.y && transform.position.y < maxYValue)
        {
            gruntYPosition += gruntSpeed * Time.deltaTime;
        }
        //bot down
        if (player.transform.position.y < transform.position.y && transform.position.y > -maxYValue)
        {
            gruntYPosition += -gruntSpeed * Time.deltaTime;
        }
        //bot right
        if (player.transform.position.x > transform.position.x && transform.position.x < maxXValue)
        {
            gruntXPosition += gruntSpeed * Time.deltaTime;
        }
        //bot left
        if (player.transform.position.x < transform.position.x && transform.position.x > -maxXValue)
        {
            gruntXPosition += -gruntSpeed * Time.deltaTime;
        }
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
        gruntHP -= damageAmount;

        if (gruntHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

