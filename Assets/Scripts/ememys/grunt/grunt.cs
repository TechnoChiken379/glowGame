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

    public static float gruntHP = 10;
    // Start is called before the first frame update
    void Start()
    {
        gruntXPosition = 5;
        gruntYPosition = 5;
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
        if (gruntHP == 0)
        {
            Destroy(gameObject);
        }
    }
}

