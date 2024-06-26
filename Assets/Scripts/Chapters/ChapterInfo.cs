using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class ChapterInfo : ScriptableObject
{
    [Header("Steps")] 
    [SerializeField] private Step[] _stepsList;
    
    [Header("Dialogues")] 
    [SerializeField] private  Dialogue[] _dialoguesList;
    

    [Header("Background")]
    [SerializeField] private Sprite[] _backgroundsList;

    [Header("Characters")] 
    [SerializeField] private Sprite[] _charactersList;
    
    public Dialogue[] GetDialogues()
    {
        return _dialoguesList;
    }

    public Sprite[] GetBackgrounds()
    {
        return _backgroundsList;
    }

    public Sprite[] GetCharacters()
    {
        return _charactersList;
    }

    public Step[] GetSteps()
    {
        return _stepsList;
    }
    
}
    

