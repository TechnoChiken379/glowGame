using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class lookAtMe : MonoBehaviour
{
    //var
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
    
    }
        


    // Update is called once per frame
    void Update()
    {
        //look at me
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
