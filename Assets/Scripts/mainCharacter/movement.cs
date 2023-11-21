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

    public static bool isMovingUp = false;
    public static bool isMovingRight = false;
    public static bool isMovingDown = false;
    public static bool isMovingLeft = false;

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
        //does movement
        if (Input.GetKey(KeyCode.W) && transform.position.y < maxYValue && characterCube.canMoveUp == true)
        {

               transform.Translate(Vector3.up * speed * Time.deltaTime);
               isMovingUp = true;
        } else
        {
            isMovingUp = false;
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -maxYValue && characterCube.canMoveDown == true)
            {

                transform.Translate(Vector3.down * speed * Time.deltaTime);
                isMovingDown = true;
            }
        else
        {
            isMovingDown = false;
        }


        if (Input.GetKey(KeyCode.D) && transform.position.x < maxXValue && characterCube.canMoveRight == true)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                isMovingRight = true;
            }
        else
        {
            isMovingRight = false;
        }


        if (Input.GetKey(KeyCode.A) && transform.position.x > -maxXValue && characterCube.canMoveLeft == true)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                isMovingLeft = true;
            }
        else
        {
            isMovingLeft = false;
        }
    }
}
