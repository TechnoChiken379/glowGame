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
    private float fireSpeed = 12;
    private float timer;
    private float canFire = 0.5f;

    private float sniperFireSpeed = 70;
    private float sniperTimer;
    private float sniperCanFire = 2f;

    private float shotGunFireSpeed = 70;
    private float shotGunTimer;
    private float shotGunCanFire = 1f;

    private float palletAmount = 7;

    void Update()
    {
        timer += Time.deltaTime;
        sniperTimer += Time.deltaTime;
        shotGunTimer += Time.deltaTime;

        if (characterCube.hotKey1 == true)
        {
            Fire();
        }
        if (characterCube.hotKey2 == true)
        {
            FireShotGun();
        }
        if (characterCube.hotKey3 == true)
        {
            SniperFire();
        }
    }

    public void Fire()
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 2);

            timer = 0f;
        }
    }

    public void SniperFire()
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 0.5f);

            timer = 0f;
        }
    }

    public void FireShotGun()
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 baseDirection = (mousePosition - bulletSpawnPoint.position).normalized;
            for (int i = 0; i < palletAmount; i++)
            {
                float randomAngle = Random.Range(-20f, 20f);
                Vector2 fireDirection = Quaternion.Euler(0, 0, randomAngle) * baseDirection;
                GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
                spawnedBullet.transform.right = fireDirection;
                spawnedBullet.GetComponent<Rigidbody2D>().velocity = fireDirection * fireSpeed;
                Destroy(spawnedBullet, 0.17f);
            }
            timer = 0f;
        }
    }
}
