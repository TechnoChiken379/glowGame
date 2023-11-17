using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
    }

    public void FireBullet()
    {
        if (Input.GetMouseButton(2))
        {
            Debug.Log("Yes");
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = bulletSpawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet, 5);
        }
        
    }
}
