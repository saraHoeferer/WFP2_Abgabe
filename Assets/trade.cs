using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class trade : MonoBehaviour
{
    [SerializeField] GameObject desiredObject;
    [SerializeField] GameObject digiPadOld;
    [SerializeField] GameObject digiPadSecret;
    public XRSocketInteractor socket1;

    public static bool tradeTriggered = false;
    
    public static bool rightItem = false;
    // Start is called before the first frame update
    void Start()
    {
        socket1 = GetComponent<XRSocketInteractor>();
    }
    public void checkItem(){
        IXRSelectInteractable objName = socket1.GetOldestInteractableSelected();
       
        Debug.Log(objName.transform.name + " in socket of " + transform.name);

        if (objName.transform.name == desiredObject.name){
            print("here");
            tradeTriggered = true;
            rightItem = true;
            desiredObject.SetActive(false);
            GameObject.Find(transform.name).SetActive(false);
            PuzzleNumbers.secret = true;
            digiPadOld.SetActive(false);
            digiPadSecret.SetActive(true);
            //key.SetActive(true);
        }
    }

    public static void activateSocket() {
         GameObject.Find("NPC Lobby").transform.GetChild(2).gameObject.SetActive(true);
    }

    public void exitItem(){
        tradeTriggered = false;
        rightItem = false;
    }
}
