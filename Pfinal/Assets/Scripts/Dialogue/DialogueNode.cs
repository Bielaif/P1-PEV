using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewNode", menuName = "DialogueSystem/Node")]
public class DialogueNode : ScriptableObject
{
    public string Speech;
    public Sprite sprite;
    public List<DialogueOptions> Options;


}


[System.Serializable]
public class DialogueOptions
{
    public string Text;
    public DialogueNode NextNode;
}