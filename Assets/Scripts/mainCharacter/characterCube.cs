using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterCube : MonoBehaviour
{
    public static float HP = 100f;
    public static float backUpHP;

    public static bool hotKey1 = false;
    public static bool hotKey2 = false;
    public static bool hotKey3 = false;

    public GameObject pistol;
    public GameObject shotGun;
    public GameObject sniper;

    public static int bossBuildIndex = 8;
    public int bossBuildIndexCount;

    boss1 boss1;
    boss2 boss2;
    boss3 boss3;
    boss4a boss4A;
    boss4b boss4B;
    boss4c boss4C;
    boss5 boss5;
    boss6 boss6;

    public static bool muteTheGame = false;

    // Start is called before the first frame update
    void Start()
    {
        backUpHP = HP;

        hotKey1 = true;
        hotKey2 = false;
        hotKey3 = false;

        pistol.SetActive(true);
        shotGun.SetActive(false);
        sniper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bossBuildIndexCount = bossBuildIndex;

        //tracts HP 
        if (HP < 1)
        {
            SceneManager.LoadScene("deathScreen");
            HP = backUpHP;
            Debug.Log(bossBuildIndex);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            HP = backUpHP;
            if (bossBuildIndex == 7)
            {
                SceneManager.LoadScene("TheMainMenu");
            }
            else if (bossBuildIndex == 8) SceneManager.LoadScene("TheMainMenu");
            else
            {
                SceneManager.LoadScene("LEVELS");
                bossBuildIndex = 7;
            }
        }

        if (Input.GetKey(KeyCode.Return))
        {
            HP = backUpHP;
            if (bossBuildIndex == 0) SceneManager.LoadScene("LEVELS");
            if (bossBuildIndex == 1) SceneManager.LoadScene("Boss 1");
            if (bossBuildIndex == 2) SceneManager.LoadScene("Boss 2");
            if (bossBuildIndex == 3) SceneManager.LoadScene("Boss 3");
            if (bossBuildIndex == 4) SceneManager.LoadScene("Boss 4");
            if (bossBuildIndex == 5) SceneManager.LoadScene("Boss 5");
            if (bossBuildIndex == 6) SceneManager.LoadScene("Boss 6");
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            hotKey1 = true;
            hotKey2 = false;
            hotKey3 = false;

            pistol.SetActive(true);
            shotGun.SetActive(false);
            sniper.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            hotKey1 = false;
            hotKey2 = true;
            hotKey3 = false;

            pistol.SetActive(false);
            shotGun.SetActive(true);
            sniper.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = true;

            pistol.SetActive(false);
            shotGun.SetActive(false);
            sniper.SetActive(true);
        }


        ////space
        //if (hotKey3 && Input.GetKeyDown(KeyCode.Space))
        //{
        //    hotKey1 = true;
        //    hotKey2 = false;
        //    hotKey3 = false;

        //    pistol.SetActive(true);
        //    shotGun.SetActive(false);
        //    sniper.SetActive(false);
        //}
        //else if (hotKey1 && Input.GetKeyDown(KeyCode.Space))
        //{
        //    hotKey1 = false;
        //    hotKey2 = true;
        //    hotKey3 = false;

        //    pistol.SetActive(false);
        //    shotGun.SetActive(true);
        //    sniper.SetActive(false);
        //}
        //else if (hotKey2 && Input.GetKeyDown(KeyCode.Space))
        //{
        //    hotKey1 = false;
        //    hotKey2 = false;
        //    hotKey3 = true;

        //    pistol.SetActive(false);
        //    shotGun.SetActive(false);
        //    sniper.SetActive(true);
        //}
        ////space

        if (Input.GetKey(KeyCode.End))
        {
            boss1.SQHP = 1;
            boss2.IBHP = 1;
            boss3.TGHP = 1;
            boss4a.CGHP = 1;
            boss4b.CGHP = 1;
            boss4c.CGHP = 1;
            boss5.MSHP = 1;
            boss6.RicardoHP = 1;
        }

        if (!MuteGame.muteTheGame)
        {
            muteTheGame = false;
        }
        else
        {
            muteTheGame = true;
        }
    }
}