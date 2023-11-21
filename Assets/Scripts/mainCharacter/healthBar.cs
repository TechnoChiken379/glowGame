using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public float xScale;
    // Start is called before the first frame update
    void Start()
    {
        xScale = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(xScale, 0.7f, 1f);
        xScale = 0.06f * characterCube.HP;
    }
}
