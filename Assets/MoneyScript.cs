using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MoneyScript : MonoBehaviour
{
     public XRSocketInteractor socket1;
    // Start is called before the first frame update
    void Start()
    {
        socket1 = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterMoney(){
        IXRSelectInteractable objName = socket1.GetOldestInteractableSelected();
       
        Debug.Log(objName.transform.name + " in socket of " + transform.name);

        if (objName.transform.name == "Coin_03"){
            gameLogic.setMoney(true);
            gameLogic.checkFound();
        } else {
            gameLogic.increaseWrongPlaceByOne();
            print(gameLogic.getWrongPlace());
        }
    }

    public void exitMoney(){
        if (gameLogic.getMoney()){
            gameLogic.setMoney(false);
        }
        
    }
}
