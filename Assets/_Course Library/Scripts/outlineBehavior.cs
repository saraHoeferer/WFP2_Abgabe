using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlineBehavior : MonoBehaviour
{
    [SerializeField] GameObject highlight;

    // Update is called once per frame
    public void onHoverEnter () {
        if (highlight.activeInHierarchy) {
            highlight.GetComponent<Outline>().enabled = true;
        }
    }

    public void OnHoverExit () {
        if (highlight.activeInHierarchy) {
            highlight.GetComponent<Outline>().enabled = false;
        }
    }
}
