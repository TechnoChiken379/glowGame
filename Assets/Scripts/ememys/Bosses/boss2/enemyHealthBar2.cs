using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthBar2 : MonoBehaviour
{
    public float xScale;
    // Start is called before the first frame update
    void Start()
    {
        xScale = 35.6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(xScale, 9f, 1f);
        xScale = 0.593f * boss2.IBHP;
    }
}
