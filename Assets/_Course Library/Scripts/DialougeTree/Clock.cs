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
    [SerializeField] TextMeshProUGUI result;

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
            result.text = "Korrekt";
            result.fontSize = 0.2f;
            result.color = Color.white;
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
            result.text = "Korrekt";
            result.fontSize = 0.2f;
            result.color = Color.white;
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
            result.text = "You";
            result.fontSize = 0.2f;
            result.color = Color.white;
            Debug.Log("Korrekt");
        }
        else{
            Debug.Log("Falsch");
        }
    }

    public void ValidateInput(){

        if(inputFieldGreenH.text == "11" && inputFieldGreenM.text == "45" && inputFieldYellowH.text == "9" && inputFieldYellowM.text == "00" && inputFieldRedH.text == "6" && inputFieldRedM.text == "15")
        {
            result.text = "You win!";
            result.fontSize = 0.1f;
            result.color = Color.white;
            Debug.Log("richtig");
        }
        else{
            result.text = "Something is not right...";
            result.fontSize = 0.1f;
            result.color = Color.white;
            Debug.Log("falsch");
        }
    }

}
