using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeScript : MonoBehaviour
{
    [SerializeField] string color;
    [SerializeField] GameObject thisCanva;

    [SerializeField] GameObject nextCanva;

    [SerializeField] GameObject hideout;

    [SerializeField] GameObject textCanva;

    [SerializeField] GameObject key;

    public static bool green = false;

    public static bool yellow = false;

    public static bool red = false;

    IEnumerator showCanva()
    {
        while (true)
        {
            thisCanva.SetActive(false);
            print("hier");
            yield return new WaitForSeconds(1);
            nextCanva.SetActive(true);
            print("hier2");
            yield break;
        }
    }
    public void onClick()
    {
        if (color == "green")
        {
            print("here grün");
            green = true;
            StartCoroutine(showCanva());
        }
        else if (color == "red")
        {
            print("here rot");
            red = true;
            StartCoroutine(showCanva());
        }
        else if (color == "yellow")
        {
            print("here gelb");
            yellow = true;
            check();
        }

    }

    public void onClickInactive()
    {
        resetButtons();
        if (color == "yellow")
        {
            print("hier falsch gelb");
            check();
        }
        else
        {
            print("hier falsch");
            StartCoroutine(showCanva());
        }
    }

    public void resetButtons()
    {
        red = false;
        yellow = false;
        green = false;
    }

    public void check()
    {
        if (green && yellow && red)
        {
            thisCanva.SetActive(false);
            hideout.SetActive(false);
            textCanva.SetActive(true);
            key.SetActive(true);
        }
        else
        {
            StartCoroutine(showCanva());
            resetButtons();
        }
    }

    public void pickupKey()
    {
        if (!gameLogic.key4)
        {
            gameLogic.key4 = true;
            textCanva.SetActive(false);
        }
    }

}
