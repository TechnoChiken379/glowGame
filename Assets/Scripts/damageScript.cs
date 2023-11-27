//using System.Collections;
//using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
//using UnityEngine;

//public class damageScript : MonoBehaviour
//{
//    public grunt gruntHealth;
//    private GameObject enemy;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        gruntHealth = GetComponent<grunt>();
//        if (collision.gameObject.CompareTag("enemy"))
//        {
//            grunt.gruntHP -= 1;
//            Debug.Log("FirstStepWorks");
//            enemy = GameObject.find //https://www.youtube.com/watch?v=anHxFtiVuiE
//        }
//        if (gruntHealth.GetComponent<gruntHP>())
//        {
//            if (collision.gameObject.CompareTag("enemy"))
//            {
//                Debug.Log("WORKING");
//                Destroy(collision.gameObject);
//            }
//        }
//    }
//}
