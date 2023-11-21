using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Damage();
    }

    // Update is called once per frame
    void Update()
   {
        
//    }

<<<<<<< HEAD
    void damage(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            grunt.gruntHP =- 1;
        }
    }
=======
//    void Damage(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("enemy"))
//        {
//            //HEAD
//            //grunt.gruntHP =- 1;
////
//            Debug.Log("This Happend");
//            grunt.gruntHP = - 1;
//        }
//        if (grunt.gruntHP == 0)
//        {
//            Destroy(gameObject);
//            Debug.Log("This Happend as well")// parent of da78e70 (.)
//        }
   }
>>>>>>> cc3b392a748e6ae24b8245b473f66190be4ec9d7


}
