using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoutDirection : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("mainCharacter").transform;

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
