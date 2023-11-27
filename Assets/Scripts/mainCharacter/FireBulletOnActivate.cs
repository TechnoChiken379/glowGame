using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 2500;

    public float timer = 0f;
    public float canFire = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        FireBullet();
    }

    public void FireBullet()
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            Debug.Log("Yes");
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = bulletSpawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * fireSpeed/* * Time.deltaTime*/;
            Destroy(spawnedBullet, 2);
            timer = 0f;
        }
        
    }
}
