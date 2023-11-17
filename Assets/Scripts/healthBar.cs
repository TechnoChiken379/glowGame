using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public float HBXPosition;
    public float HBYPosition;
    public float HBZPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(HBXPosition, HBYPosition, HBZPosition);
        HBXPosition = 3.338341f;
        HBYPosition = 7f;
        HBZPosition = 4.3258f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
