using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bossCheckIndicator : MonoBehaviour
{
    public TMP_Text boss1Text;
    public static bool boss1Check = false;

    public TMP_Text boss2Text;
    public static bool boss2Check = false;

    public TMP_Text boss3Text;
    public static bool boss3Check = false;

    public TMP_Text boss4Text;
    public static bool boss4Check = false;

    public TMP_Text boss5Text;
    public static bool boss5Check = false;

    public TMP_Text boss6Text;
    public static bool boss6Check = false;

    public static bool allBossesDead = false;

    void Start()
    {
        
    }

    void Update()
    {
        deafetedBossTextChecker();
    }

    public void deafetedBossTextChecker()
    {
        if (boss1Check == true) boss1Text.text = ("BOSS 1 IS DEAD");
        else if (boss1Check == false) boss1Text.text = ("BOSS 1 IS ALIVE");

        if (boss2Check == true) boss2Text.text = ("BOSS 2 IS DEAD");
        else if (boss2Check == false) boss2Text.text = ("BOSS 2 IS ALIVE");

        if (boss3Check == true) boss3Text.text = ("BOSS 3 IS DEAD");
        else if (boss3Check == false) boss3Text.text = ("BOSS 3 IS ALIVE");
        
        if (boss4Check == true) boss4Text.text = ("BOSS 4 IS DEAD");
        else if (boss4Check == false) boss4Text.text = ("BOSS 4 IS ALIVE");
        
        if (boss5Check == true) boss5Text.text = ("BOSS 5 IS DEAD");
        else if (boss5Check == false) boss5Text.text = ("BOSS 5 IS ALIVE");
        
        if (boss6Check == true) boss6Text.text = ("BOSS 6 IS DEAD");
        else if (boss6Check == false) boss6Text.text = ("BOSS 6 IS ALIVE");


        if (boss1Check == true && boss2Check == true && boss3Check == true && boss4Check == true && boss5Check == true && boss6Check == true)
        {
            allBossesDead = true;
        }
        else allBossesDead = false;
    }
}