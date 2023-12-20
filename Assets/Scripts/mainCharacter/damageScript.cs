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

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //gruntHealth = GetComponent<grunt>();
    //    if (collision.gameObject.CompareTag("enemy"))
    //    {
    //        enemy = collision.gameObject;
    //        gruntHealth = enemy.GetComponent<grunt>();
    //        gruntHealth.DamageDealt(1);
    //    }
    //    if (grunt.gruntHP == 0)
    //    {
    //        if (collision.gameObject.CompareTag("enemy"))
    //        {
    //            Debug.Log("WORKING");
    //            Destroy(collision.gameObject);
    //        }
    //    }
    //}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //gruntHealth = GetComponent<grunt>();
    //    if (collision.gameObject.CompareTag("enemy"))
    //    {
    //        enemy = collision.gameObject;
    //        gruntHealth = enemy.GetComponent<grunt>();
    //        gruntHealth.DamageDealt(1);
    //    }
    //    if (grunt.gruntHP == 0)
    //    {
    //        if (collision.gameObject.CompareTag("enemy"))
    //        {
    //            Debug.Log("WORKING");
    //            Destroy(collision.gameObject);
    //        }
    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<grunt>(out grunt enemyComponent))
        {
            enemyComponent.DamageDealt(1);
            Destroy(transform.gameObject);
        }

        if (collision.gameObject.TryGetComponent<boss1>(out boss1 bossComponent))
        {
            bossComponent.DamageDealt(1);
            Destroy(transform.gameObject);
        }

        if (collision.gameObject.TryGetComponent<boss2>(out boss2 boss2Component))
        {
            boss2Component.DamageDealt(1);
            Destroy(transform.gameObject);
        }

        if (collision.gameObject.TryGetComponent<boss3>(out boss3 boss3Component))
        {
            boss3Component.DamageDealt(1);
            Destroy(transform.gameObject);
        }

        if (collision.gameObject.TryGetComponent<boss4>(out boss4 boss4Component))
        {
            boss4Component.DamageDealt(1);
            Destroy(transform.gameObject);
        }

        if (collision.gameObject.TryGetComponent<boss5>(out boss5 boss5Component))
        {
            boss5Component.DamageDealt(1);
            Destroy(transform.gameObject);
        }
    }
}
