using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterController : MonoBehaviour
{
    public static ChapterController Instance { get; private set; }

    [SerializeField] private ChapterInfo _chapterInfo;


    private Step[] _steps;

   [SerializeField]  private StepController _stepController;

    private void Start()
    {
        _steps = GetSteps();
        _stepController.AddStep(_steps[0]);
        
        NextStepClick();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextStepClick()
    {
        _stepController.ExecuteNextStep();
    }
    
    public Dialogue[] GetDialogues()
    {
        return _chapterInfo.GetDialogues();
    }

    public Sprite[] GetBackgrounds()
    {
        return _chapterInfo.GetBackgrounds();
    }

    public Sprite[] GetCharacters()
    {
        return _chapterInfo.GetCharacters();
    }

    public Step[] GetSteps()
    {
        return _chapterInfo.GetSteps();
    }
    
    
}
