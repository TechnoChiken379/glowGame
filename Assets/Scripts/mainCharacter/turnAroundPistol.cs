using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;

public class turnAroundPistol : MonoBehaviour
{
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
       rotation = Mathf.Clamp(rotation, 0f, 180f);
       transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
