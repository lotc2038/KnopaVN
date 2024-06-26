using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instanse { get; private set; }

    private void Awake()
    {
        Instanse = this;
    }
    
    [SerializeField] private GameObject choiceButtonPrefab;
    private  Dialogue[] _dialoguesList; // Dialogues SO array
    private Dictionary<int, Dialogue> _dialogues;
    private Dictionary<(int,int), DialogueNode> _dialogueNodes; // Dialogues and nodes id's
    private DialogueNode _currentNode;

    private void Start()
    {
         _dialoguesList = ChapterController.Instance.GetDialogues(); 
         LoadDialogues();
    }
    
 
    // Writing to dictionaries dialogues and nodes
    private void LoadDialogues()
    {
        _dialogues = new Dictionary<int, Dialogue>();
        _dialogueNodes = new Dictionary<(int, int), DialogueNode>();
        
        foreach (var dialogue in _dialoguesList)
        {
            _dialogues[dialogue.dialogueId] = dialogue;
            foreach (var node in dialogue.nodes)
            {
                _dialogueNodes[(dialogue.dialogueId, node.nodeId)] = node; 
            }
        }
        
    }

    public void StartDialogue(int dialogueId)
    {
        _currentNode = _dialoguesList[dialogueId].nodes[0]; // Starting from 1st node
        DisplayText();
    }

    private void DisplayText()
    {
        HUD.Instance._dialogueText.text = _currentNode.dialogueText;
        DisplayOptions();
    }

    private void DisplayOptions()
    {
        foreach (Transform child in HUD.Instance._dialogueOptionsList.transform)
        {
            Destroy(child.gameObject);
        }
        
        for (int i = 0; i < _currentNode.choices.Count; i++) // Instantiate for each option on node
        {
            DialogueChoice choice = _currentNode.choices[i];
            GameObject choiceButton = Instantiate(choiceButtonPrefab, HUD.Instance._dialogueOptionsList.transform);
            TMP_Text choiceText = choiceButton.GetComponentInChildren<TMP_Text>();
            choiceText.text = choice.choiceText;
            int choiceIndex = i;  
            choiceButton.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(choiceIndex));
        }
    }
    
    private void OnChoiceSelected(int choiceIndex)
    {
        int nextNodeId = _currentNode.choices[choiceIndex].nextNodeId;
        Dialogue currentDialogue = _dialogues.Values.First(d => d.nodes.Contains(_currentNode)); 
        int currentDialogueId = currentDialogue.dialogueId; 

        if (_dialogueNodes.TryGetValue((currentDialogueId, nextNodeId), out DialogueNode nextNode))
        {
            _currentNode = nextNode; 
            DisplayText(); 
        }
        else
        {
            Debug.LogError($"Node with ID {nextNodeId} not found in dialogue with ID {currentDialogueId}!");
        }
    }
    
}
