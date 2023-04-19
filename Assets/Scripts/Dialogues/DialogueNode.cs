using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueNode", menuName = "Dialogue Node", order = 51)]
public class DialogueNode : ScriptableObject
{
    [TextArea(3, 10)]
    public string text;
    public string[] answers;
    public DialogueNode[] nextNode;
}
