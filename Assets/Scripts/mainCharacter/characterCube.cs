using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterCube : MonoBehaviour
{
    //var
    public static int bossBuildIndex = 0;

    public static float HP = 100f;
    public static float backUpHP;
    
    // Start is called before the first frame update
    void Start()
    {
        backUpHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
    //tracts HP 
        if (HP < 1)
        {
            SceneManager.LoadScene("deathScreen");
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("LEVELS");
        }
        if (Input.GetKey(KeyCode.Return))
        {
            if (bossBuildIndex == 0) SceneManager.LoadScene("Boss 1");
            if (bossBuildIndex == 1) SceneManager.LoadScene("Boss 2");
            if (bossBuildIndex == 2) SceneManager.LoadScene("Boss 3");
            if (bossBuildIndex == 3) SceneManager.LoadScene("Boss 4");
            if (bossBuildIndex == 4) SceneManager.LoadScene("Boss 5");
            if (bossBuildIndex == 5) SceneManager.LoadScene("Boss 6");
        }
    }
}
