using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle4 : MonoBehaviour
{
    public static int wrongGuess = 0;
    // Start is called before the first frame update

    public static void solutionFound() {
        GameObject.Find("keyDrawer4").SetActive(false);
    }
}
