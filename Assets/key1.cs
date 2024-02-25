using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class key1 : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] GameObject doorHandle;
    public XRSocketInteractor socket1;
    // Start is called before the first frame update
    void Start()
    {
        socket1 = GetComponent<XRSocketInteractor>();
    }
    public void enterKey(){
        IXRSelectInteractable objName = socket1.GetOldestInteractableSelected();
       
        Debug.Log(objName.transform.name + " in socket of " + transform.name);

        if (objName.transform.name == key.name){
            print("here");
            key.SetActive(false);
            if (key.name == "KeyPuzzle4Object" ) {
                SceneManager.LoadScene(2);
            } else {
                doorHandle.SetActive(true);
                GameObject.Find(transform.name).SetActive(false);
            }
        }
    }
}
