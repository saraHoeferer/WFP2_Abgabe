using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class bookScript : MonoBehaviour
{
    public XRSocketInteractor socket1;

    [SerializeField] GameObject correspondingBook;

    private static bool book1 = false;

    private static bool book2 = false;

    private static bool book3 = false;

    private static bool book4 = false;

    // Start is called before the first frame update
    void Start()
    {
        socket1 = GetComponent<XRSocketInteractor>();
    }

    public void enterBook()
    {
        IXRSelectInteractable objName = socket1.GetOldestInteractableSelected();

        Debug.Log(objName.transform.name + " in socket of " + transform.name);

        if (objName.transform.name == correspondingBook.name)
        {
            if (correspondingBook.name == "Book1")
            {
                book1 = true;
                printBools();
            }
            else if (correspondingBook.name == "Book2")
            {
                book2 = true;
                printBools();
            }
            else if (correspondingBook.name == "Book3")
            {
                book3 = true;
                printBools();
            }
            else if (correspondingBook.name == "Book4")
            {
                book4 = true;
                printBools();
            }
            checkSolution();
        }
    }

    public void exitBook()
    {
        print("here");
        if (correspondingBook.name == "Book1")
        {
            book1 = true;
            print("1 " + book1);
        }
        else if (correspondingBook.name == "Book2")
        {
            book2 = true;
            print("2 " + book2);
        }
        else if (correspondingBook.name == "Book2")
        {
            book3 = true;
            print("3 " + book3);
        }
        else if (correspondingBook.name == "Book2")
        {
            book4 = true;
            print("4 " + book4);
        }
    }

    public void printBools() {
         print("1 " + book1);
         print("2 " + book2);
         print("3 " + book3);
         print("4 " + book4);
    }

    public void checkSolution() {
        if (book1 && book2 && book3 && book4) {
           showKey();
        }
    }

    public void showKey() {
        GameObject.Find("drawerKey").SetActive(false);
        GameObject.Find("keyPuzzle3").transform.GetChild(1).gameObject.SetActive(true);
    }

    public void pickupKey() {
        if (!gameLogic.key2) {
            gameLogic.key2 = true;
            GameObject.Find("keyTextPuzzle3").SetActive(false);
        }
    }
}
