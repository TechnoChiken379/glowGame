using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class enemyDamageScriptSnipe : MonoBehaviour
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
            characterCube.HP -= 20 * controlScript.controlDamage;
        }
        //    if (grunt.gruntHP == 0)
        //    {
        //        Debug.Log("SecondStepWorks");
        //        Destroy(gameObject);
        //    }
    }


}
