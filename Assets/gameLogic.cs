using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class gameLogic : MonoBehaviour
{
    public static bool key = false;
    private static bool axe = false;
    private static bool soup = false;
    private static bool bottle = false;
    private static bool money = false;
    private static int wrongPlace = 0;

    private static bool inventory = false;

    private static bool found = false;

    public static bool key1 = false;

    public static bool key2 = false;

    public static bool key3 = false;

    public static bool key4 = false;

    private AudioSource sounds;
    // Start is called before the first frame update
    void Start()
    {
        //sounds = GameObject.Find("EventSystem").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!found){
            if (axe && soup && bottle && money) {
                print("here");
                found = true;
                GameObject.Find("draware").transform.TransformDirection(0.006f,6131249f,0.5f);
                sounds.Play();
            }
        }*/
    }

    public static void checkFound() {
        if (axe && soup && bottle && money) {
            print("here");
            GameObject.Find("drawer").SetActive(false);
            GameObject.Find("key").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("key").transform.GetChild(1).gameObject.SetActive(true);
        } else {
            print("noch nicht found");
        }
    }

    public static void pickupKey() {
        if (!found) {
            GameObject.Find("key").transform.GetChild(1).gameObject.SetActive(false);
            found = true;
        }
    }

    public static void setAxe (bool axe1){
        axe = axe1;
        print(axe);
    }

    public static bool getAxe (){
        return axe;
    }

    public static void setSoup (bool soup1){
        soup = soup1;
        print(soup);
    }

    public static bool getSoup (){
        return soup;
    }

    public static void setBottle (bool bottle1){
        bottle = bottle1;
        print(bottle);
    }

    public static bool getBottle (){
        return bottle;
    }

    public static void setMoney (bool money1){
        money = money1;
        print(money);
    }

    public static bool getMoney (){
        return money;
    }

    public static bool getInventory(){
        return inventory;
    }

    public static void setInventoy(bool inventory1){
        inventory = inventory1;
    }

    public static int getWrongPlace() {
        return wrongPlace;
    }

    public static void setWrongPlace(int wrongPlace1) {
        wrongPlace = wrongPlace1;
    }

    public static void increaseWrongPlaceByOne() {
        wrongPlace++;
    }
}
