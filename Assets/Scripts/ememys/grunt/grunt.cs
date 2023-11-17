using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grunt : MonoBehaviour
{
    public GameObject player;
    public float gruntXPosition;
    public float gruntYPosition;

    float maxXValue = 8.6f;
    float maxYValue = 4.7f;
    public float gruntSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
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
}

