using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Interactions;

public class DialogeDisplayyer3 : MonoBehaviour
{
    public static DialogeDisplayyer3 instance;

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;

    [SerializeField] GameObject dialogueBox;

    [SerializeField] GameObject answerBox;

    [SerializeField] GameObject[] answerObjects;

    public DialougeTree dialogueTree;
    bool answerTriggered;
    int answerIndex;

    bool alreadyTalked = false;

    int check = 1;

    bool chair = false;
    bool bath = false;

    bool drawer = false;

    bool seating = false;

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
        ResetBools();
        check = 1;
        nameText.text = name;
        dialogueBox.SetActive(true);
        if (!alreadyTalked)
        {
            StartCoroutine(RunDialogue(dialogueTree, 0));
        }
        else
        {
            StartCoroutine(RunDialogue(dialogueTree, 7));
        }
    }

    IEnumerator RunDialogue(DialougeTree dialogueTree, int section)
    {

        if (section == 1)
        {
            if (check == 5)
            {
                print("Hat vier mal geraten");
                if (chair && bath && seating && drawer)
                {
                    print("hat richtig geraten");
                    StartCoroutine(RunDialogue(dialogueTree, 8));
                }
                else
                {
                    puzzle4.wrongGuess++;
                    ResetBools();
                    check = 1;
                    StartCoroutine(RunDialogue(dialogueTree, 9));
                }
                yield break;
            }
        }

        if (section == 8)
        {
            puzzle4.solutionFound();
            print("here haha");
        }

        if (section == 1 && check == 2)
        {
            dialogueText.text = "Right! So what happend next?";
            yield return new WaitForSeconds(3);
        }
        else if (section == 1 && check == 3)
        {
            dialogueText.text = "Remarkable! And then what?";
            yield return new WaitForSeconds(3);
        }
        else if (section == 1 && check == 4)
        {
            dialogueText.text = "Ohh I remember! What happened at last?";
            yield return new WaitForSeconds(3);
        }
        else
        {
            for (int i = 0; i < dialogueTree.sections[section].dialogue.Length; i++)
            {
                dialogueText.text = dialogueTree.sections[section].dialogue[i];
                yield return new WaitForSeconds(3);
            }
        }


        if (section == 2)
        {
            print("here");
            print(puzzle4.wrongGuess);
            if (puzzle4.wrongGuess < 2)
            {
                StartCoroutine(RunDialogue(dialogueTree, 4));
                yield break;
            }
            else if (puzzle4.wrongGuess >= 2 && puzzle4.wrongGuess < 4)
            {
                StartCoroutine(RunDialogue(dialogueTree, 5));
                yield break;
            }
            else if (puzzle4.wrongGuess >= 4)
            {
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

        if (!(section == 1))
        {
            dialogueText.text = dialogueTree.sections[section].branchPoint.question;
        }
        ShowAnswers(dialogueTree.sections[section].branchPoint);

        while (answerTriggered == false)
        {
            yield return null;
        }

        if (section == 1)
        {
            check++;
            print(check);
            if (answerIndex == 0)
            {
                print("Hier Antwort 1");
                if (!chair)
                {
                    if (bath && drawer && !seating)
                    {
                        chair = true;
                    }
                    else
                    {
                        ResetBools();
                    }
                }
                else
                {
                    ResetBools();
                }
            }
            else if (answerIndex == 1)
            {
                print("Hier Antwort 2");
                if (!drawer)
                {
                    if (bath && !seating && !chair)
                    {
                        drawer = true;
                    }
                    else
                    {
                        ResetBools();
                    }
                }
                else
                {
                    ResetBools();
                }
            }
            else if (answerIndex == 2)
            {
                print("Hier Antwort 3");
                if (!bath)
                {
                    if (!chair && !drawer && !seating)
                    {
                        bath = true;
                    }
                    else
                    {
                        ResetBools();
                    }
                }
                else
                {
                    ResetBools();
                }
            }
            else if (answerIndex == 3)
            {
                print("Hier Antwort 4");
                if (!seating)
                {
                    if (chair && bath && drawer)
                    {
                        seating = true;
                    }
                    else
                    {
                        ResetBools();
                    }
                }
                else
                {
                    ResetBools();
                }
            }
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
        answerTriggered = false;
        ResetBools();
        check = 1;
    }

    void ResetBools()
    {
        print("Reseted");
        chair = false;
        bath = false;
        seating = false;
        drawer = false;
    }

    void ShowAnswers(BranchPoint branchPoint)
    {
        // Reveals the aselectable answers and sets their text values
        answerBox.SetActive(true);
        for (int i = 0; i < answerObjects.Length; i++)
        {
            if (i < branchPoint.answers.Length)
            {
                answerObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = branchPoint.answers[i].answerLabel;
                answerObjects[i].gameObject.SetActive(true);
            }
            else
            {
                answerObjects[i].gameObject.SetActive(false);
            }
        }
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
