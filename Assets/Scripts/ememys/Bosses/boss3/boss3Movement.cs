using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss3Movement : MonoBehaviour
{
    public float speed = 4f;
    private float minMax = 7;
    private float yPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    public void Moving()
    {
        transform.position = new Vector3(7.5f, yPosition, 0);
        yPosition = transform.position.y * speed * Time.deltaTime;

        if (transform.position.y <= -minMax)
        {
            yPosition *= -1;
        }
        if (transform.position.y >= minMax)
        {
            yPosition *= -1;
        }
    }
}
