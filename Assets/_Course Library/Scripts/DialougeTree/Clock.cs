using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour
{
    // Start is called before the first frame update

    //private int input;
    [SerializeField] InputField inputFieldGreenH;
    [SerializeField] InputField inputFieldGreenM;
    [SerializeField] InputField inputFieldYellowH;
    [SerializeField] InputField inputFieldYellowM;
    [SerializeField] InputField inputFieldRedH;
    [SerializeField] InputField inputFieldRedM;
    [SerializeField] GameObject textCanva;

    [SerializeField] GameObject Hideout;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ValidateInputGreen()
    {
        if(inputFieldGreenH.text == "3" && inputFieldGreenM.text == "00")
        {
            Debug.Log("Korrekt");
        }
        else{
            Debug.Log("Falsch");
        }
    }

    public void ValidateInputYellow()
    {
        if(inputFieldYellowH.text == "9" && inputFieldYellowM.text == "00")
        {
            Debug.Log("Korrekt");
        }
        else{
            Debug.Log("Falsch");
        }

    }

    public void ValidateInputRed()
    {
        if(inputFieldRedH.text == "9" && inputFieldRedM.text == "30")
        {
            Debug.Log("Korrekt");
        }
        else{
            Debug.Log("Falsch");
        }
    }

    public void ValidateInput(){

        if(inputFieldGreenH.text == "11" && inputFieldGreenM.text == "45" && inputFieldYellowH.text == "9" && inputFieldYellowM.text == "00" && inputFieldRedH.text == "6" && inputFieldRedM.text == "15")
        {
            Hideout.SetActive(false);
            textCanva.SetActive(true);
            Debug.Log("richtig");
        }
        else{
            Debug.Log("falsch");
        }
    }

    public void pickupKey() {
        if (!gameLogic.key4) {
            gameLogic.key4 = true;
            textCanva.SetActive(false);
        }
    }

}
