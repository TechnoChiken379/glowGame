using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{

    //var
    //float maxXValue = 8.6f;
    //float maxYValue = 4.7f;
    public float speed = 5;
    private float moveX;
    private float moveY;

    //public static bool isMovingUp = false;
    //public static bool isMovingRight = false;
    //public static bool isMovingDown = false;
    //public static bool isMovingLeft = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move();
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(moveX, moveY, 0);
    }
}
