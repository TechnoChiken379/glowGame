using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class controlScript : MonoBehaviour
{
    public static float controlDamage;
    public static float controlAttackSpeed;
    public static float controlGruntSpawnRate;

    public static bool easyMode = false;
    public static bool mediumMode = false;
    public static bool hardMode = false;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;


    // Start is called before the first frame update
    void Start()
    {
        easyButton.onClick.AddListener(easyModeSettings);
        mediumButton.onClick.AddListener(mediumModeSettings);
        hardButton.onClick.AddListener(hardModeSettings);

        controlDamage = 0.5f; //make damage lower for less damage, higher for more
        controlAttackSpeed = 2f; // make attack speed higher for slower attacks, lower for faster attacks
        controlGruntSpawnRate = 1f; //make higher to spawn less grunts, lower to spawn more

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controlDamage);
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
        Debug.Log("settingscheck");
        if (easyMode == true)
        {
            controlDamage = 0.5f; //make damage lower for less damage, higher for more
            controlAttackSpeed = 2f; // make attack speed higher for slower attacks, lower for faster attacks
            controlGruntSpawnRate = 1f; //make higher to spawn less grunts, lower to spawn more

            Debug.Log("eMode");

            easyMode = false;
            mediumMode = false;
            hardMode = false;
        }
        else if (mediumMode == true)
        {
            controlDamage = 0.8f; //make damage lower for less damage, higher for more
            controlAttackSpeed = 1.2f; // make attack speed higher for slower attacks, lower for faster attacks
            controlGruntSpawnRate = 0.6f; //make higher to spawn less grunts, lower to spawn more

            Debug.Log("mMode");

            easyMode = false;
            mediumMode = false;
            hardMode = false;
        }
        else if (hardMode == true)
        {
            controlDamage = 1f; //make damage lower for less damage, higher for more
            controlAttackSpeed = 0.9f; // make attack speed higher for slower attacks, lower for faster attacks
            controlGruntSpawnRate = 0.4f; //make higher to spawn less grunts, lower to spawn more

            Debug.Log("hMode");

            easyMode = false;
            mediumMode = false;
            hardMode = false;
        }
    }
}