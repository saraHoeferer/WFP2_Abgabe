using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlineBehavior : MonoBehaviour
{
    [SerializeField] GameObject highlight;

    // Update is called once per frame
    public void onHoverEnter () {
        print(highlight);
        print(highlight.GetComponent<Outline>());
        highlight.GetComponent<Outline>().enabled = true;
    }

    public void OnHoverExit () {
        highlight.GetComponent<Outline>().enabled = false;
    }
}
