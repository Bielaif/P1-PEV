using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "DialogueSystem/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string Name;
    public DialogueNode StartNode;
}


