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

    void damage(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            grunt.gruntHP =- 1;
        }
    }


}
