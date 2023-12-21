using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShotgunDamageScript : MonoBehaviour
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            Destroy(transform.gameObject);
            Debug.Log("Obstacle detected!");
            characterCube.HP -= 3;
        }
        //    if (grunt.gruntHP == 0)
        //    {
        //        Debug.Log("SecondStepWorks");
        //        Destroy(gameObject);
        //    }
    }


}

