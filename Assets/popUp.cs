using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    // Start is called before the first frame update
   public void onClick() {
        StartCoroutine(showText());

   }

   IEnumerator showText() {
     while(true) {
        dialogueBox.SetActive(true);
        yield return new WaitForSeconds(5);
        dialogueBox.SetActive(false);
        yield break;
     }
   }
}
