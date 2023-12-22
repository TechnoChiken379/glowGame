using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class teleportation1 : MonoBehaviour
{
    GameObject bigSquare;
    GameObject bigSquare1;
    GameObject bigSquare2;
    GameObject smallSquare;
    GameObject smallSquare1;
    GameObject smallSquare2;
    GameObject smallSquare3;
    GameObject smallSquare4;

    private float timer;
    private float canTeleport = 0.2f;

    private float changeTimer;
    private float changeTeleports = 5;

    public Material canNotTelePort;
    public Material canTeleportblue;
    public Material canTeleportYellow;

    private int chooseBigSquare1;
    private int chooseBigSquare2;

    private int chooseSmallSquare1;
    private int chooseSmallSquare2;

    private bool choseBigSquare;
    private bool choseBigSquare1;
    private bool choseBigSquare2;

    private bool choseSmallSquare;
    private bool choseSmallSquare1;
    private bool choseSmallSquare2;
    private bool choseSmallSquare3;
    private bool choseSmallSquare4;
    // Start is called before the first frame update
    void Start()
    {
        bigSquare = GameObject.Find("bigSquare");
        bigSquare1 = GameObject.Find("bigSquare (1)");
        bigSquare2 = GameObject.Find("bigSquare (2)");
        smallSquare = GameObject.Find("smallSquare");
        smallSquare1 = GameObject.Find("smallSquare (1)");
        smallSquare2 = GameObject.Find("smallSquare (2)");
        smallSquare3 = GameObject.Find("smallSquare (3)");
        smallSquare4 = GameObject.Find("smallSquare (4)");

        ChooseRandomTeleportSquares();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        changeTimer += Time.deltaTime;
        if (changeTimer > changeTeleports) 
        {
            ChooseRandomTeleportSquares();
            changeTimer = 0;
        }
    }

    void ChooseRandomTeleportSquares()
    {
        bigSquare.GetComponent<Renderer>().sharedMaterial = canNotTelePort;
        bigSquare1.GetComponent<Renderer>().sharedMaterial = canNotTelePort;
        bigSquare2.GetComponent<Renderer>().sharedMaterial = canNotTelePort;
        smallSquare.GetComponent<Renderer>().sharedMaterial = canNotTelePort;
        smallSquare1.GetComponent<Renderer>().sharedMaterial = canNotTelePort;
        smallSquare2.GetComponent<Renderer>().sharedMaterial = canNotTelePort;
        smallSquare3.GetComponent<Renderer>().sharedMaterial = canNotTelePort;
        smallSquare4.GetComponent<Renderer>().sharedMaterial = canNotTelePort;

        choseBigSquare = false;
        choseBigSquare1 = false;
        choseBigSquare2 = false;

        choseSmallSquare = false;
        choseSmallSquare1 = false;
        choseSmallSquare2 = false;
        choseSmallSquare3 = false;
        choseSmallSquare4 = false;

        ChooseBigSquare();
        ChooseSmallSquare();

        if (chooseBigSquare1 == 1 || chooseBigSquare2 == 1)
        {
            choseBigSquare = true;
            bigSquare.GetComponent<Renderer>().sharedMaterial = canTeleportblue;
        }
        if (chooseBigSquare1 == 2 || chooseBigSquare2 == 2)
        {
            choseBigSquare1 = true;
            bigSquare1.GetComponent<Renderer>().sharedMaterial = canTeleportblue;
        }
        if (chooseBigSquare1 == 3 || chooseBigSquare2 == 3)
        {
            choseBigSquare2 = true;
            bigSquare2.GetComponent<Renderer>().sharedMaterial = canTeleportblue;
        }



        if (chooseSmallSquare1 == 1 || chooseSmallSquare2 == 1)
        {
            choseSmallSquare = true;
            smallSquare.GetComponent<Renderer>().sharedMaterial = canTeleportYellow;
        }
        if (chooseSmallSquare1 == 2 || chooseSmallSquare2 == 2)
        {
            choseSmallSquare1 = true;
            smallSquare1.GetComponent<Renderer>().sharedMaterial = canTeleportYellow;
        }
        if (chooseSmallSquare1 == 3 || chooseSmallSquare2 == 3)
        {
            choseSmallSquare2 = true;
            smallSquare2.GetComponent<Renderer>().sharedMaterial = canTeleportYellow;
        }
        if (chooseSmallSquare1 == 4 || chooseSmallSquare2 == 4)
        {
            choseSmallSquare3 = true;
            smallSquare3.GetComponent<Renderer>().sharedMaterial = canTeleportYellow;
        }
        if (chooseSmallSquare1 == 5 || chooseSmallSquare2 == 5)
        {
            choseSmallSquare4 = true;
            smallSquare4.GetComponent<Renderer>().sharedMaterial = canTeleportYellow;
        }



    }
    private void ChooseBigSquare()
    {
        chooseBigSquare1 = Random.RandomRange(1, 4);
        chooseBigSquare2 = Random.RandomRange(1, 4);
        if (chooseBigSquare1 == chooseBigSquare2)
        {
            ChooseBigSquare();
        }
    }
    private void ChooseSmallSquare()
    {
        chooseSmallSquare1 = Random.RandomRange(1, 6);
        chooseSmallSquare2 = Random.RandomRange(1, 6);
        if (chooseSmallSquare1 == chooseSmallSquare2)
        {
            ChooseSmallSquare();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && timer >= canTeleport)
        {


            if (collision.gameObject == bigSquare && choseBigSquare == true)
            {
                if (choseBigSquare1 == true)
                {
                transform.position = bigSquare1.transform.position;
                }
                if (choseBigSquare2 == true)
                {
                    transform.position = bigSquare2.transform.position;
                }
            }
            if (collision.gameObject == bigSquare1 && choseBigSquare1 == true)
            {
                if (choseBigSquare == true)
                {
                    transform.position = bigSquare.transform.position;
                }
                if (choseBigSquare2 == true)
                {
                    transform.position = bigSquare2.transform.position;
                }
            }
            if (collision.gameObject == bigSquare2 && choseBigSquare2 == true)
            {
                if (choseBigSquare == true)
                {
                    transform.position = bigSquare.transform.position;
                }
                if (choseBigSquare1 == true)
                {
                    transform.position = bigSquare1.transform.position;
                }
            }




            if (collision.gameObject == smallSquare && choseSmallSquare == true)
            {
                if (choseSmallSquare1 == true)
                {
                    transform.position = smallSquare1.transform.position;
                }
                if (choseSmallSquare2 == true)
                {
                    transform.position = smallSquare2.transform.position;
                }
                if (choseSmallSquare3 == true)
                {
                    transform.position = smallSquare3.transform.position;
                }
                if (choseSmallSquare4 == true)
                {
                    transform.position = smallSquare4.transform.position;
                }
            }
            if (collision.gameObject == smallSquare1 && choseSmallSquare1 == true)
            {
                if (choseSmallSquare == true)
                {
                    transform.position = smallSquare.transform.position;
                }
                if (choseSmallSquare2 == true)
                {
                    transform.position = smallSquare2.transform.position;
                }
                if (choseSmallSquare3 == true)
                {
                    transform.position = smallSquare3.transform.position;
                }
                if (choseSmallSquare4 == true)
                {
                    transform.position = smallSquare4.transform.position;
                }
            }
            if (collision.gameObject == smallSquare2 && choseSmallSquare2 == true)
            {
                if (choseSmallSquare == true)
                {
                    transform.position = smallSquare.transform.position;
                }
                if (choseSmallSquare1 == true)
                {
                    transform.position = smallSquare1.transform.position;
                }
                if (choseSmallSquare3 == true)
                {
                    transform.position = smallSquare3.transform.position;
                }
                if (choseSmallSquare4 == true)
                {
                    transform.position = smallSquare4.transform.position;
                }
            }
            if (collision.gameObject == smallSquare3 && choseSmallSquare3 == true)
            {
                if (choseSmallSquare == true)
                {
                    transform.position = smallSquare.transform.position;
                }
                if (choseSmallSquare1 == true)
                {
                    transform.position = smallSquare1.transform.position;
                }
                if (choseSmallSquare2 == true)
                {
                    transform.position = smallSquare2.transform.position;
                }
                if (choseSmallSquare4 == true)
                {
                    transform.position = smallSquare4.transform.position;
                }
            }
            if (collision.gameObject == smallSquare4 && choseSmallSquare4 == true)
            {
                if (choseSmallSquare == true)
                {
                    transform.position = smallSquare.transform.position;
                }
                if (choseSmallSquare1 == true)
                {
                    transform.position = smallSquare1.transform.position;
                }
                if (choseSmallSquare2 == true)
                {
                    transform.position = smallSquare2.transform.position;
                }
                if (choseSmallSquare3 == true)
                {
                    transform.position = smallSquare3.transform.position;
                }
            }
            timer = 0;
        }
    }
}
