using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    //var
    int maxValue;
    int minValue;
    int speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < maxValue)
        {

            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && transform.position.y > -maxValue)
        {

            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
