using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCube : MonoBehaviour
{
    //var
    public static bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("Obstacle detected!");
        }
        
    }
}
