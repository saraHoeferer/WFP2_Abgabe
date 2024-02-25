using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNumbers : MonoBehaviour
{
    [SerializeField] GameObject hideout;

    [SerializeField] GameObject text;

    [SerializeField] GameObject key;
    private bool number1 = false;
    private bool number2 = false;
    private bool number3 = false;

    public static int wrongDigit = 0;

    public static bool secret = false;

    public void onClickNotActive()
    {
        Reset();
        printNumbers();
    }

    public void onClick1()
    {
        if (!number1)
        {
            if (!number2 && !number3)
            {
                number1 = true;
            }
            else
            {
                Reset();
            }
        }
        else
        {
            Reset();
        }
        printNumbers();
    }

    public void onClick2()
    {
        if (!number2)
        {
            if (!number3 && number1)
            {
                number2 = true;
            }
            else
            {
                Reset();
            }
        }
        else
        {
            Reset();
        }
        printNumbers();
    }

    public void onClick3()
    {
        if (!number3)
        {
            if (number2 && number1)
            {
                number3 = true;
                solutionFound();
            }
            else
            {
                Reset();
            }
        }
        else
        {
            Reset();
        }
        printNumbers();
    }

    public void printNumbers()
    {
        print("click " + wrongDigit);
        print("1 " + number1);
        print("2 " + number2);
        print("3 " + number3);

    }

    public void solutionFound()
    {
        print("here");
        hideout.SetActive(false);
        if (!gameLogic.key1) {
            key.SetActive(true);
            text.gameObject.SetActive(true);
        } else if (secret) {
            key.SetActive(true);
            text.gameObject.SetActive(true);
        }
    }

    public void pickUpTrade() {
        hideout.SetActive(true);
    }

    public void pickupKey() {
        if (!gameLogic.key1) {
            gameLogic.key1 = true;
            text.SetActive(false);
            hideout.SetActive(true);
        }
    }


    public void Reset()
    {
        if (!number1 || !number2 || !number3)
        {
            wrongDigit++;
        }

        number1 = false;
        number2 = false;
        number3 = false;

    }
}
