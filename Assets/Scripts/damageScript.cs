using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    private grunt gruntHealth;
    private GameObject enemy;

    public static float damageAmount = 0.5f;
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
        //gruntHealth = GetComponent<grunt>();
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemy = collision.gameObject;
            gruntHealth = enemy.GetComponent<grunt>();
            gruntHealth.DamageDealt(1);
        }
        if (grunt.gruntHP == 0)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                Debug.Log("WORKING");
                Destroy(collision.gameObject);
            }
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent<grunt>(out grunt enemyComponent))
    //    {
    //        enemyComponent.DamageDealt(1);
    //    }
    //}
}
