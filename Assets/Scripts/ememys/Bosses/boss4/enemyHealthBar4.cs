using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyHealthBar4 : MonoBehaviour
{
    public float xScale;
    private float totalCGHP;

    // Start is called before the first frame update
    void Start()
    {
        xScale = 35.6f;
    }

    // Update is called once per frame
    void Update()
    {
        totalCGHP = boss4a.CGHP + boss4b.CGHP + boss4c.CGHP;
        transform.localScale = new Vector3(xScale, 9f, 1f);
        xScale = 0.475f * totalCGHP;

        if (totalCGHP <= 0)
        {
            Destroy(gameObject);
            characterCube.HP = characterCube.backUpHP;
            SceneManager.LoadScene("winScreen");
        }

    }
}
