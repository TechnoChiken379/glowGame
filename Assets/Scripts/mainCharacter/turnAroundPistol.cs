using System.Collections;
using System.Collections.Generic;
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


        if (90f > autoAim.Rotation && 0f < autoAim.Rotation)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (360f > autoAim.Rotation && 270f < autoAim.Rotation)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (270f > autoAim.Rotation && 90f < autoAim.Rotation)
        {
            transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
        }
        rotationCheck = autoAim.Rotation;
    }
}
