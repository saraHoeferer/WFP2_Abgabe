using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] bool firstInteraction = true;
    [SerializeField] int repeatStartPosition;

    public string npcName;
    public DialogueAsset dialogueAsset;

    [HideInInspector]
    public int startPostion {
        get {
            if (firstInteraction) {
                firstInteraction = false;
                return 0;
            } else {
                return repeatStartPosition;
            }
        }
    }
}
