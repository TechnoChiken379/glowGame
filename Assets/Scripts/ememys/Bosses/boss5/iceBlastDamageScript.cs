using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class iceBlastDamageScript : MonoBehaviour
{
    private Transform player;
    public Transform iceBlastSpawnPoint;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);
        transform.rotation = rotation;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mainCharacter"))
        {
            characterCube.HP -= 20 * controlScript.controlDamage;
            Destroy(transform.gameObject);
        }
    }
}
