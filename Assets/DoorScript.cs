using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class DoorScript : MonoBehaviour
{
    private AudioSource sounds;
    // Start is called before the first frame update
    void Start()
    {
         sounds = GameObject.Find("MOD_Door_interior").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSelect(){
        if (gameLogic.key)
        {
            sounds.Play();
            print("here! true");
        }
        else
        {
            print("KEY fehlt");
        }
    }
}
