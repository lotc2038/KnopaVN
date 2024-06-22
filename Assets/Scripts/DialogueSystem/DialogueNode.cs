using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
  public int nodeId;
  [TextArea(3, 10)] public string dialogueText;
  public List<DialogueChoice> choices;
}



