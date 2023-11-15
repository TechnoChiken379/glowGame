using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{

    //var
    float maxXValue = 8.6f;
    float maxYValue = 4.7f;
    public float speed = 5;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (characterCube.canMove == true)
        {
            if (Input.GetKey(KeyCode.W) && transform.position.y < maxYValue)
            {

                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S) && transform.position.y > -maxYValue)
            {

                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && transform.position.x < maxXValue)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x > -maxXValue)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }
}
