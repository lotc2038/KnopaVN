using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ChapterBase : MonoBehaviour
{
    [SerializeField] private Dialogue[] _dialoguesList;
    private Dictionary<int, Dialogue> _dialogues;
    private Dictionary<int, DialogueNode> _dialogueNodes;
    private DialogueNode _currentNode;
    [SerializeField] private GameObject choiceButtonPrefab;

    private void Start()
    {
        LoadDialogues();
        StartChapter();
    }

   private void LoadDialogues()
    {
        _dialogues = new Dictionary<int, Dialogue>();
        _dialogueNodes = new Dictionary<int, DialogueNode>();
        foreach (var dialogue in _dialoguesList)
        {
            _dialogues[dialogue.dialogueId] = dialogue;
            foreach (var node in dialogue.nodes)
            {
                _dialogueNodes[node.nodeId] = node;
            }
        }
    }

    private void StartChapter()
    {
        _currentNode = _dialoguesList[0].nodes[0];
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
        
        for (int i = 0; i < _currentNode.choices.Count; i++)
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
        if (_dialogueNodes.TryGetValue(nextNodeId, out DialogueNode nextNode))
        {
            _currentNode = nextNode;
            DisplayText();
        }
        else
        {
            Debug.LogError($"Node with ID {nextNodeId} not found!");
        }
    }
    
}
