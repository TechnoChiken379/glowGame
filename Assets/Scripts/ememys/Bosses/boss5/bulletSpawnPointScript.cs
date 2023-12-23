using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bulletSpawnPointScript : MonoBehaviour
{
    private float xMax = 8.1f;
    private float yMax = 4.2f;

    private float xMin = -8.1f;
    private float yMin = -4.2f;

    public float xPosition;
    public float yPosition;

    private float chooseNewPosition = 2f;
    private float moveTimer;
    // Start is called before the first frame update
    void Start()
    {
        chooseNewPosition *= controlScript.controlAttackSpeed;


    }

    // Update is called once per frame
    void Update()
    {
        moveTimer += Time.deltaTime;
        Move();
    }

    void Move()
    {
        if (moveTimer >= chooseNewPosition)
        {
            xPosition = Random.Range(xMin, xMax);
            yPosition = Random.Range(yMin, yMax);
            moveTimer = 0;
        }
        transform.position = new Vector3 (xPosition, yPosition, 0);
    }
}
