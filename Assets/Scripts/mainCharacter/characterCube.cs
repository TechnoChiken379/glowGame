using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCube : MonoBehaviour
{
    //var
    public static bool canMoveUp = true;
    public static bool canMoveRight = true;
    public static bool canMoveDown = true;
    public static bool canMoveLeft = true;

    public static float HP = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //canMoveUp = true;
    //canMoveRight = true;
    //canMoveDown = true;
    //canMoveLeft = true;
    if (HP < 1)
        {
            Debug.Log("player died!");
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object
        if (collision.gameObject.CompareTag("Obstacle") && movement.isMovingUp == true)
        {
            canMoveUp = false;
            Debug.Log("Obstacle detected!");
        }
        if (collision.gameObject.CompareTag("Obstacle") && movement.isMovingRight == true)
        {
            canMoveRight = false;
            Debug.Log("Obstacle detected!");
        }
        if (collision.gameObject.CompareTag("Obstacle") && movement.isMovingDown == true)
        {
            canMoveDown = false;
            Debug.Log("Obstacle detected!");
        }
        if (collision.gameObject.CompareTag("Obstacle") && movement.isMovingLeft == true)
        {
            canMoveLeft = false;
            Debug.Log("Obstacle detected!");
        }

        }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            canMoveUp = true;
            canMoveRight = true;
            canMoveDown = true;
            canMoveLeft = true;
        }

    }

}
