using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    public int dialogueId;
    public List<DialogueNode> nodes;
}
