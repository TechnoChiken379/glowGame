using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamageScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            characterCube.HP -= 5;
            Destroy(transform.gameObject);
        }
    }
}
