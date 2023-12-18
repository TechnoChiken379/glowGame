using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterCube : MonoBehaviour
{
    //var

    public static float HP = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //tracts HP 
    if (HP < 1)
        {
            SceneManager.LoadScene("deathScreen");
            Debug.Log("player died!");
        }

    }
}
