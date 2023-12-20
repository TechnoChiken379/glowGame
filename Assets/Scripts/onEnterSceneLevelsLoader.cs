using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onEnterSceneLevelsLoader : MonoBehaviour
{
    void Update()
    {
        sceneLoad();
    }

    public void sceneLoad()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            Debug.Log("ENTER PRESSED");
            SceneManager.LoadScene("LEVELS");
        }
    }
}
