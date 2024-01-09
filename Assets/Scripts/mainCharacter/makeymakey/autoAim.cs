//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class autoAim : MonoBehaviour
//{
//    public static float Rotation;
//    private Transform enemy;
//    private Transform enemy1;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    //void Update()
//    //{
//    //    Rotation = transform.localEulerAngles.z;
//    //    enemy = GameObject.FindGameObjectWithTag("enemy1").transform; 
//    //    enemy1 = GameObject.FindGameObjectWithTag("enemy").transform;
//    //    //look at me 
//    //    //var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
//    //    float distanceToEnemy = Vector2.Distance(transform.position, enemy1.position);
//    //    if (distanceToEnemy < 10f)
//    //    var dir = enemy1.transform.position;
//    //    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//    //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//    //}

//    void Update()
//    {
//        enemy = GameObject.FindGameObjectWithTag("enemy1").transform;
//        enemy1 = GameObject.FindGameObjectWithTag("enemy").transform;

//        // Check if both enemies are found before attempting to aim
//        if (enemy != null && enemy1 != null)
//        {
//            // Calculate the direction to the closest enemy
//            Vector3 dirToEnemy1 = enemy1.position - (Vector3)transform.position;
//            Vector3 dirToEnemy = enemy.position - (Vector3)transform.position;

//            // Check which enemy is closer
//            Transform targetEnemy = (dirToEnemy1.sqrMagnitude < dirToEnemy.sqrMagnitude) ? enemy1 : enemy;

//            // Rotate towards the target enemy
//            float angle = Mathf.Atan2(targetEnemy.position.y - transform.position.y, targetEnemy.position.x - transform.position.x) * Mathf.Rad2Deg;
//            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoAim : MonoBehaviour
{
    public static float Rotation;

    private Transform playerTransform;
    private GameObject[] enemies;
    private GameObject[] enemies1;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemies();
        Rotation = transform.localEulerAngles.z;
    }

    void FindClosestEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemies1 = GameObject.FindGameObjectsWithTag("enemy1");

        Transform closestEnemy = GetClosestEnemy(enemies);
        Transform closestEnemy1 = GetClosestEnemy(enemies1);

        if (closestEnemy != null || closestEnemy1 != null)
        {
            // Compare distances and select the closest enemy
            if (closestEnemy != null && closestEnemy1 != null)
            {
                float distanceToEnemy = Vector2.Distance(playerTransform.position, closestEnemy.position);
                float distanceToEnemy1 = Vector2.Distance(playerTransform.position, closestEnemy1.position);

                Transform targetEnemy = (distanceToEnemy < distanceToEnemy1) ? closestEnemy : closestEnemy1;

                // Rotate towards the closest enemy
                Vector2 direction = targetEnemy.position - playerTransform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else if (closestEnemy != null)
            {
                // Rotate towards the closest enemy
                Vector2 direction = closestEnemy.position - playerTransform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else
            {
                // Rotate towards the closest enemy1
                Vector2 direction = closestEnemy1.position - playerTransform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    Transform GetClosestEnemy(GameObject[] enemiesArray)
    {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemiesArray)
        {
            float distanceToEnemy = Vector2.Distance(playerTransform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }
}
