using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FireBulletOnActivate : MonoBehaviour
{
    public characterCube characterCube;
    public Transform bulletSpawnPoint;

    public GameObject bullet;
    public float fireSpeed = 12;
    public float timer = 0f;
    public float canFire = 0.25f;

    public GameObject sniperBullet;
    public float sniperFireSpeed = 12;
    public float sniperTimer = 0f;
    public float sniperCanFire = 0.25f;

    public GameObject shotGunBullet;
    public float shotGunFireSpeed = 12;
    public float shotGunTimer = 0f;
    public float shotGunCanFire = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (characterCube.hotKey1 == true)
        {
            FirePistol();
        }
        if (characterCube.hotKey2 == true)
        {
            FireShotGun();
        }
        if (characterCube.hotKey3 == true)
        {
            FireSniper();
        }
    }

    public void FirePistol()
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 2);
            timer = 0f;
        }
    }

    public void FireShotGun()
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(shotGunBullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 2);
            timer = 0f;
        }
    }

    public void FireSniper()
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(sniperBullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 2);
            timer = 0f;
        }
    }
}
