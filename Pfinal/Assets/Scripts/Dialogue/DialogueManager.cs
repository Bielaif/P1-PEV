using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Animator _animator;
    public static DialogueManager Instance;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Speech;
    public Image expression;
    public TextMeshProUGUI[] Options;

    private DialogueNode _currentNode;
    private GameObject _talker;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this); //esto garantiza que solo haya una instancia.
        }
    }
    void Start()
    {
    _animator = GetComponent<Animator>();
    }
    public void StartDialogue(Dialogue dialogue, GameObject talker)
    {
        _talker = talker;
        Name.text = dialogue.Name;
        SetNode(dialogue.StartNode);
        Show();
    }
    public void OptionChosen(int number)
    {
        DialogueNode nextNode = _currentNode.Options[number].NextNode;
        if(nextNode is EndNode)
        {
            EndNode endNode = nextNode as EndNode;
            endNode.EndAction(_talker);
            Hide();
        }
        else
        {
            SetNode(nextNode);
        }


    }
    private void SetNode(DialogueNode node)
    {
        _currentNode = node;
        Speech.text = node.Speech;
        expression.sprite  = node.sprite;
        for(int i = 0; i < Options.Length; i++)
        {
            if (i < node.Options.Count)
            {
                Options[i].transform.parent.gameObject.SetActive(true);
                Options[i].text = node.Options[i].Text;
            }
            else
            {
                Options[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void Show()
    {
        _animator.SetBool("Show",true);
    }
    public void Hide()
    {
        _animator.SetBool("Show", false);
    }
}
