using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BottleScript : MonoBehaviour
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

    public void enterBottle(){
        IXRSelectInteractable objName = socket1.GetOldestInteractableSelected();
       
        Debug.Log(objName.transform.name + " in socket of " + transform.name);

        if (objName.transform.name == "Bottle_01"){
            gameLogic.setBottle(true);
            gameLogic.checkFound();
        } else {
            gameLogic.increaseWrongPlaceByOne();
            print(gameLogic.getWrongPlace());
        }
    }

    public void exitBottle(){
        if (gameLogic.getBottle()){
            gameLogic.setBottle(false);
        }
        
    }
}
