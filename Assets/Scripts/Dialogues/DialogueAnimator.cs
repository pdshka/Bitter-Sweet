using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager DM;
    public GameObject text;
    private void Start()
    {
        text.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (text.active)
            {
                if (!DM.dialogueStarted)
                {
                    text.SetActive(false);
                    DM.StartDialogue(dialogue);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
        DM.EndDialogue();
    }
}
