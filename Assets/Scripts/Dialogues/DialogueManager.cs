using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text DialogueText;
    public Text NameText;
    public GameObject BoxDialogue;
    private Queue<string> sentencess;

    private void Start()
    {
        sentencess = new Queue<string>();
        BoxDialogue.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        BoxDialogue.SetActive(true);
        NameText.text = dialogue.name;
        sentencess.Clear();
        foreach (string sentences in dialogue.sentences)
        {
            sentencess.Enqueue(sentences);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentencess.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentences = sentencess.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentences(sentences));
    }

    IEnumerator TypeSentences(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        BoxDialogue.SetActive(false);
    }
}
