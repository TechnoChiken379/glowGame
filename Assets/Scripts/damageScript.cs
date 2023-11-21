using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            grunt.gruntHP =- 1;
            Debug.Log("FirstStepWorks");
        }
        if (grunt.gruntHP == 0)
        {
            Destroy(gameObject);
            Debug.Log("SecondStepWorks");
        }
    }
}
