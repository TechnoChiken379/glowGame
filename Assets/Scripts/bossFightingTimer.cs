using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bossFightingTimer : MonoBehaviour
{
    public static int bossFightingTimerINT;
    public static float bossFightingTimerFLOAT;

    public TMP_Text bossFightingTimerIndicator;

    void Start()
    {
        
    }

    void Update()
    {
        bossFightingTimerIndicator.text = bossFightingTimerINT.ToString() + (" Seconds Boss Fighting Time");
    }
}
