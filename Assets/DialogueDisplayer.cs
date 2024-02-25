using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogeDisplayyer : MonoBehaviour
{
    public static DialogeDisplayyer instance;

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;

    [SerializeField] GameObject dialogueBox;

    [SerializeField] GameObject answerBox;

    [SerializeField] GameObject[] answerObjects;

    public DialougeTree dialogueTree;

    bool skipLineTriggered;
    bool answerTriggered;
    int answerIndex;

    bool alreadyTalked = false;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartDialogue()
    {
        ResetBox();
        nameText.text = name;
        dialogueBox.SetActive(true);
        if (!alreadyTalked) {
            StartCoroutine(RunDialogue(dialogueTree, 0));
        } else {
             StartCoroutine(RunDialogue(dialogueTree, 7));
        }
    }

    IEnumerator RunDialogue(DialougeTree dialogueTree, int section)
    {
        

        for (int i = 0; i < dialogueTree.sections[section].dialogue.Length; i++)
        {
            dialogueText.text = dialogueTree.sections[section].dialogue[i];
            yield return new WaitForSeconds(3);
        }

        if (section == 1) {
            if (!PuzzleNumbers.secret){
                trade.activateSocket();
                while(trade.tradeTriggered == false ){
                    yield return null;
                }

                if (trade.rightItem) {
                    StartCoroutine(RunDialogue(dialogueTree, 9));
                    yield break;
                } else {
                    StartCoroutine(RunDialogue(dialogueTree, 8));
                    yield break;
                }
            } else {
                StartCoroutine(RunDialogue(dialogueTree, 9));
                yield break;
            }
        }

        if (section == 2) {
            print("here");
            print(PuzzleNumbers.wrongDigit);
            if (PuzzleNumbers.wrongDigit < 5) {
                StartCoroutine(RunDialogue(dialogueTree, 4));
                yield break;
            } else if (PuzzleNumbers.wrongDigit >= 5 && PuzzleNumbers.wrongDigit < 10) {
                StartCoroutine(RunDialogue(dialogueTree, 5));
                yield break;
            } else if (PuzzleNumbers.wrongDigit >= 10) {
                StartCoroutine(RunDialogue(dialogueTree, 6));
                yield break;
            }
        }

        if (dialogueTree.sections[section].endAfterDialogue)
        {
            dialogueBox.SetActive(false);
            alreadyTalked = true;
            yield break;
        }

        dialogueText.text = dialogueTree.sections[section].branchPoint.question;
        ShowAnswers(dialogueTree.sections[section].branchPoint);

        while (answerTriggered == false)
        {
            yield return null;
        }
        answerBox.SetActive(false);
        answerTriggered = false;

        StartCoroutine(RunDialogue(dialogueTree, dialogueTree.sections[section].branchPoint.answers[answerIndex].nextElement));
    }

    void ResetBox()
    {
        StopAllCoroutines();
        dialogueBox.SetActive(false);
        answerBox.SetActive(false);
        skipLineTriggered = false;
        answerTriggered = false;
    }

    void ShowAnswers(BranchPoint branchPoint)
    {
        // Reveals the aselectable answers and sets their text values
        answerBox.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            if (i < branchPoint.answers.Length)
            {
                answerObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = branchPoint.answers[i].answerLabel;
                answerObjects[i].gameObject.SetActive(true);
            }
            else {
                answerObjects[i].gameObject.SetActive(false);
            }
        }
    }

    public void SkipLine()
    {
        skipLineTriggered = true;
    }

    public void AnswerQuestion(int answer)
    {
        answerIndex = answer;
        answerTriggered = true;
    }

    /*[SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;

    public DialogueObject currentDialogue;

    private void Start()
    {
        DisplayDialogue(currentDialogue);
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;

            //The following line of code makes it so that the for loop is paused until the user clicks the left mouse button.
            yield return new WaitForSeconds(10);
            //The following line of code makes the coroutine wait for a frame so as the next WaitUntil is not skipped
            yield return null;
        }
        dialogueBox.SetActive(false);
    }

    public void DisplayDialogue(DialogueObject dialogueObject)
    {
        StartCoroutine(MoveThroughDialogue(dialogueObject));
    }*/
}
