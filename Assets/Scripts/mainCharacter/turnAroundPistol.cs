using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;

public class turnAroundPistol : MonoBehaviour
{
    public float rotationCheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (90f > lookAtMe.Rotation && 0f < lookAtMe.Rotation)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (360f > lookAtMe.Rotation && 270f < lookAtMe.Rotation)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (270f > lookAtMe.Rotation && 90f < lookAtMe.Rotation)
        {
            transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
        }
        rotationCheck = lookAtMe.Rotation;


    }
}
