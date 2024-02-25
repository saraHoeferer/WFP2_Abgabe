using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InventoryScript : MonoBehaviour
{
    public XRSocketInteractor socket1;
    private GameObject inventoryObject;

    private GameObject inventoryText;

    private GameObject inventory1;

    private GameObject inventory1Item;
    private GameObject inventory2;

    private GameObject inventory2Item;

    private GameObject inventory3;

    private GameObject inventory3Item;

    private GameObject imageInventory;
    private bool pickup = false;
    // Start is called before the first frame update
    void Start()
    {
        socket1 = GetComponent<XRSocketInteractor>();
        imageInventory = GameObject.Find("imageInventory");
        inventory1 = imageInventory.transform.GetChild(0).gameObject;
        inventory2 = imageInventory.transform.GetChild(1).gameObject;
        inventory3 = imageInventory.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void enterObject()
    {
        if (!pickup)
        {
            print("hier enter");
            IXRSelectInteractable objName = socket1.GetOldestInteractableSelected();
            Debug.Log(objName.transform.name + " in socket of " + transform.name);
            inventoryObject = GameObject.Find(objName.transform.name);

            if (!inventory1.activeInHierarchy)
            {
                print("inventory 1 availabel");
                inventory1.GetComponentInChildren<TextMeshProUGUI>().SetText(objName.transform.name);
                inventory1Item = inventoryObject;
                inventoryObject.SetActive(false);
                inventory1.SetActive(true);
            }
            else if (!inventory2.activeInHierarchy)
            {
                print("inventory 2 available");
                inventory2.GetComponentInChildren<TextMeshProUGUI>().SetText(objName.transform.name);
                inventory2Item = inventoryObject;
                inventoryObject.SetActive(false);
                inventory2.SetActive(true);
            }
            else if (!inventory3.activeInHierarchy)
            {
                print("inventory 3 available");
                inventory3.GetComponentInChildren<TextMeshProUGUI>().SetText(objName.transform.name);
                inventory3Item = inventoryObject;
                inventoryObject.SetActive(false);
                inventory3.SetActive(true);
            }
            else
            {
                print("no inventory available");
            }
        }
    }

    public void exitAxe()
    {
        print("hier exti");
        if (pickup)
        {
            pickup = false;
        }

    }

    public void removeFromInventory1()
    {
        if (inventory1.activeInHierarchy)
        {
            inventory1Item.SetActive(true);
            inventory1.SetActive(false);
            pickup = true;
        }
    }

    public void removeFromInventory2()
    {
        if (inventory2.activeInHierarchy)
        {
            inventory2Item.SetActive(true);
            inventory2.SetActive(false);
            pickup = true;
        }
    }

    public void removeFromInventory3()
    {
        if (inventory3.activeInHierarchy)
        {
            inventory3Item.SetActive(true);
            inventory3.SetActive(false);
            pickup = true;
        }
    }

    public void getInventory()
    {
        print("hier check");
        if (gameLogic.getInventory())
        {
            inventoryObject.SetActive(true);
            pickup = true;
        }
    }
}
