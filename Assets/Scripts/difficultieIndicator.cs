using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class difficultieIndicator : MonoBehaviour
{
    public controlScript ControlScript;
    public TMP_Text textMP;

    void Start()
    {
        
    }

    void Update()
    {
        textUpdater();
    }

    void textUpdater()
    {
        if (controlScript.eMode == true)
        {
            textMP.text = ("EASY");
        }
        else if (controlScript.mMode == true) textMP.SetText("MEDIUM");
        else if (controlScript.hMode == true) textMP.SetText("HARD");
    }
}
