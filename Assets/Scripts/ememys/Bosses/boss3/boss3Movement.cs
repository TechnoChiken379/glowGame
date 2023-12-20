using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss3Movement : MonoBehaviour
{
    public float speed = 4f;
    private float minMax = 3.5f;
    private float yPosition;
    private float xPosition = 7.5f;

    private float canSwitch = 4f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Moving();
        if (timer >= canSwitch)
        {
            SwitchSides();
        }
    }

    public void Moving()
    {
        yPosition = transform.position.y + speed * Time.deltaTime;

        if (yPosition > minMax || yPosition < -minMax)
        {
            speed *= -1;
        }

        transform.position = new Vector3(xPosition, yPosition, 0);
    }

    private void SwitchSides()
    {
        xPosition *= -1;
        transform.position = new Vector3(xPosition, yPosition, 0);
        timer = 0;
    }
}
