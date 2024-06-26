using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DialogueChoice
{
    [TextArea(3, 10)] public string choiceText;
    public int nextNodeId;
}
