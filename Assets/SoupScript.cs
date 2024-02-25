using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoupScript : MonoBehaviour
{
    // Start is called before the first frame update
    public XRSocketInteractor socket1;

    void Start()
    {
        socket1 = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void enterSoup(){
        IXRSelectInteractable objName = socket1.GetOldestInteractableSelected();
       
        Debug.Log(objName.transform.name + " in socket of " + transform.name);

        if (objName.transform.name == "Plate_04"){
            gameLogic.setSoup(true);
            gameLogic.checkFound();
        } else {
            gameLogic.increaseWrongPlaceByOne();
            print(gameLogic.getWrongPlace());
        }
    }

    public void exitSoup(){
        if (gameLogic.getSoup()){
            gameLogic.setSoup(false);
        }
        
    }
}
