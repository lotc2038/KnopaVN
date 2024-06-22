using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : PanelBase
{
    [Header("Buttons")]
    [SerializeField] private Button _pauseButton;

    [SerializeField] public Image _dialogueTextBox;
    [SerializeField] public TMP_Text _dialogueText;
    [SerializeField] public Transform _dialogueOptionsList;

    public static HUD Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    protected override void OnOpened() 
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick()
    {
        //Сделать меню паузы
    }

    protected override void OnClosed()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
    }
    
}
