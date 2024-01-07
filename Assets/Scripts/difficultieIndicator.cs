using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class difficultieIndicator : MonoBehaviour
{
    public controlScript ControlScript;
    public TMP_Text textMP;

    public static bool startDifficultie = false;

    void Start()
    {
        
    }

    void Update()
    {
        textUpdater();
        if (controlScript.easyMode == false && controlScript.mediumMode == false && controlScript.hardMode == false)
        {
            startDifficultie = true;
        }
        else
        {
            startDifficultie = false;
        }
    }

    void textUpdater()
    {
        if (controlScript.eMode == true) textMP.text = ("EASY");
        else if (controlScript.mMode == true) textMP.SetText("MEDIUM");
        else if (controlScript.hMode == true) textMP.SetText("HARD");
    }
}
