using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class controlScript : MonoBehaviour
{
    public static float controlDamage = 0.75f; //make damage lower for less damage, higher for more
    public static float controlAttackSpeed = 1.5f; //make attack speed higher for slower attacks, lower for faster attacks
    public static float controlGruntSpawnRate = 1.25f; //make higher to spawn less grunts, lower to spawn more

    public static bool easyMode;
    public static bool mediumMode;
    public static bool hardMode;

    public static bool hMode;
    public static bool mMode;
    public static bool eMode;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    void Start()
    {
        easyButton.onClick.AddListener(easyModeSettings);
        mediumButton.onClick.AddListener(mediumModeSettings);
        hardButton.onClick.AddListener(hardModeSettings);

        easyMode = true;
        settingsChecker();
    }

    public void easyModeSettings()
    {
        easyMode = true;
        mediumMode = false;
        hardMode = false;

        settingsChecker();
    }

    public void mediumModeSettings()
    {
        easyMode = false;
        mediumMode = true;
        hardMode = false;

        settingsChecker();
    }

    public void hardModeSettings()
    {
        easyMode = false;
        mediumMode = false;
        hardMode = true;

        settingsChecker();
    }

    private void settingsChecker()
    {
        if (easyMode == true)
        {
            controlDamage = 0.5f; //make damage lower for less damage, higher for more
            controlAttackSpeed = 2f; // make attack speed higher for slower attacks, lower for faster attacks
            controlGruntSpawnRate = 1.5f; //make higher to spawn less grunts, lower to spawn more

            eMode = true;
            mMode = false;
            hMode = false;
        }
        else if (mediumMode == true)
        {
            controlDamage = 0.75f; //make damage lower for less damage, higher for more
            controlAttackSpeed = 1.5f; //make attack speed higher for slower attacks, lower for faster attacks
            controlGruntSpawnRate = 1.25f; //make higher to spawn less grunts, lower to spawn more

            eMode = false;
            mMode = true;
            hMode = false;
        }
        else if (hardMode == true)
        {
            controlDamage = 1f; //make damage lower for less damage, higher for more
            controlAttackSpeed = 1f; // make attack speed higher for slower attacks, lower for faster attacks
            controlGruntSpawnRate = 1f; //make higher to spawn less grunts, lower to spawn more

            eMode = false;
            mMode = false;
            hMode = true;
        }
    }
}