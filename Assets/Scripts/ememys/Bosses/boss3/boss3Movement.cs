using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss3Movement : MonoBehaviour
{
    public float speed = 4f;
    private float minMax = 3.5f;
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
        yPosition = transform.position.y + speed * Time.deltaTime;

        if (yPosition > minMax || yPosition < -minMax)
        {
            speed *= -1;
        }

        transform.position = new Vector3(7.5f, yPosition, 0);
    }
}
