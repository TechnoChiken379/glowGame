using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteGame : MonoBehaviour
{
    public static bool muteTheGame = false;
    public GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        muteTheGame = characterCube.muteTheGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            muteTheGame = !muteTheGame; // Toggle the mute state
        }

        if (!muteTheGame)
        {
            music.SetActive(true);
        }
        else
        {
            music.SetActive(false);
        }
    }
}