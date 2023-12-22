using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    private grunt gruntHealth;
    private GameObject enemy;

    private float damageAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characterCube.hotKey1)
        {
            damageAmount = 2f;
        } else if (characterCube.hotKey2)
        {
            damageAmount = 0.7f;
        } else if (characterCube.hotKey3)
        {
            damageAmount = 7f;
        }
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


    // boss4 sometimes bounces bullets off without taking damage, i think this is because they are moving away from player.
    // and because it's collision stay it doesn't have time to see the bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<grunt>(out grunt enemyComponent))
        {
            enemyComponent.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<zombieGrunt>(out zombieGrunt enemyZombieComponent))
        {
            enemyZombieComponent.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<boss1>(out boss1 bossComponent))
        {
            bossComponent.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<boss2>(out boss2 boss2Component))
        {
            boss2Component.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<boss3>(out boss3 boss3Component))
        {
            boss3Component.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<boss4a>(out boss4a boss4aComponent))
        {
            boss4aComponent.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<boss4b>(out boss4b boss4bComponent))
        {
            boss4bComponent.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<boss4c>(out boss4c boss4cComponent))
        {
            boss4cComponent.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<boss5>(out boss5 boss5Component))
        {
            boss5Component.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent<boss6>(out boss6 boss6Component))
        {
            boss6Component.DamageDealt(damageAmount);
            if (characterCube.hotKey1 || characterCube.hotKey2)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
