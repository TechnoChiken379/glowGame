using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnAroundPistol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
