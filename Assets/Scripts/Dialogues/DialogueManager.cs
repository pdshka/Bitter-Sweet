using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text DialogueText;
    public Text NameText;
    public GameObject BoxDialogue;
    private bool nextNodeEnabled;
    private Queue<DialogueNode> nodes;
    public GameObject[] AnswerButtons;
    private DialogueNode currentNode;
    public bool dialogueStarted;
    public bool dialogueEnded;

    private void Start()
    {
        nodes = new Queue<DialogueNode>();
        BoxDialogue.SetActive(false);
        nextNodeEnabled = false;
        dialogueStarted = false;
        dialogueEnded = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (nextNodeEnabled)
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DisableButtons();
        dialogueStarted = true;
        nextNodeEnabled = false;
        BoxDialogue.SetActive(true);
        NameText.text = dialogue.name;
        nodes.Clear();
        //foreach (string sentences in dialogue.sentences)
        //{
        //    sentencess.Enqueue(sentences);
        //}
        nodes.Enqueue(dialogue.node);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        nextNodeEnabled = false;
        if (nodes.Count == 0)
        {
            EndDialogue();
            return;
        }

        currentNode = nodes.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentNode));
    }

    IEnumerator TypeSentence(DialogueNode sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.text.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }

        // end of dialog
        if (sentence.answers.Length == 0 && sentence.nextNode.Length == 0)
        {
            nextNodeEnabled = true;
        }
        // without branching
        else if (sentence.answers.Length == 0 && sentence.nextNode.Length > 0)
        {
            if (sentence.nextNode.Length > 1) Debug.LogWarning("¬ узле диалога без ответов больше одного следующего узла. Ѕудет показан только первый");
            nodes.Enqueue(sentence.nextNode[0]);
            nextNodeEnabled = true;
        }
        // branching
        else if (sentence.answers.Length == sentence.nextNode.Length)
        {
            //nodes.Enqueue(sentence.nextNode[0]);
            for(int i = 0; i < sentence.answers.Length; i++)
            {
                AnswerButtons[i].SetActive(true);
                AnswerButtons[i].GetComponent<Text>().text = "> " + sentence.answers[i];
            }
        }
        else
        {
            Debug.LogError("Ќесоответствие кол-ва ответов и следующих узлов.");
        }
    }

    public void EndDialogue()
    {
        dialogueEnded = true;
        dialogueStarted = false;
        nextNodeEnabled = false;
        foreach (var ansBtn in AnswerButtons)
            ansBtn.SetActive(false);
        BoxDialogue.SetActive(false);
    }

    public void Answer(int ans)
    {
        Debug.Log("Trying to answer " + ans);
        DisableButtons();
        nodes.Enqueue(currentNode.nextNode[ans]);
        DisplayNextSentence();
    }

    public void DisableButtons()
    {
        foreach (var ansBtn in AnswerButtons)
            ansBtn.SetActive(false);
    }
}
