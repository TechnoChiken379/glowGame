using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    public grunt gruntHealth;
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
        gruntHealth = GetComponent<grunt>();
        if (collision.gameObject.CompareTag("enemy"))
        {
            grunt.gruntHP -= 1;
            Debug.Log("FirstStepWorks");
            
        }
        if (gruntHealth.GetComponent<gruntHP>())
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                Debug.Log("WORKING");
                Destroy(collision.gameObject);
            }
        }
    }
}
