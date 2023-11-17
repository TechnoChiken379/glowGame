using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 2500;
    public float reloadSpeed = 10f;
    public float fireDelay = 0.5f;

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
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Bullet Spawned");
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = bulletSpawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * fireSpeed * Time.deltaTime;
            Destroy(spawnedBullet, 5);
        }
        
    }

}
