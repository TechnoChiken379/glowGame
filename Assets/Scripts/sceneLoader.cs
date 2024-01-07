using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneLoader : MonoBehaviour
{
    public characterCube characterCube;
    public bossCheckIndicator bossCheckIndicator;

    public Button restartGameButton;
    public Button Button;
    public Button L1Button;
    public Button L2Button;
    public Button L3Button;
    public Button L4Button;
    public Button L5Button;
    public Button L6Button;

    private void Start()
    {
        restartGameButton.onClick.AddListener(RestartGame);

        Button.onClick.AddListener(OnClick);

        L1Button.onClick.AddListener(NewOnClick);
        L2Button.onClick.AddListener(NewOnClick);
        L3Button.onClick.AddListener(NewOnClick);
        L4Button.onClick.AddListener(NewOnClick);
        L5Button.onClick.AddListener(NewOnClick);
        L6Button.onClick.AddListener(NewOnClick);
    }

    private void OnClick()
    {
        characterCube.bossBuildIndex = 8;
    }

    private void NewOnClick()
    {
        characterCube.bossBuildIndex = 0;
    }

    public void LoadNextInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("TheMainMenu");
        bossCheckIndicator.boss1Check = false;
        bossCheckIndicator.boss2Check = false;
        bossCheckIndicator.boss3Check = false;
        bossCheckIndicator.boss4Check = false;
        bossCheckIndicator.boss5Check = false;
        bossCheckIndicator.boss6Check = false;
    }
}