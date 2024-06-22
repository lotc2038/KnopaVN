using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Chapter : ScriptableObject
{
    [SerializeField] private Dialogue[] _dialoguesList;
    [SerializeField] private Image[] _backgroundImagesList;
    [SerializeField] private Image[] _charactersImagesList;
}
