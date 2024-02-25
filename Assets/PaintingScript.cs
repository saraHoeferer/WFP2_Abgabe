using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    AudioSource sounds;
    Animation animations;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GameObject.Find("P_PROP_painting_interior_02").GetComponent<AudioSource>();
        animations = GameObject.Find("P_PROP_painting_interior_02").GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move(){
        print("hier");
        GameObject.Find("P_PROP_painting_interior_02").transform.Rotate(100,90,90);
        sounds.Play();
    }
}
