
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeDialogStep", menuName = "Step/ChangeDialogStep") ]
public class StartDialogTextStep : Step
{
    [SerializeField] private int id;
    [SerializeField] private int _nextId;
    [SerializeField] private int _dialogueID;
    //private string text;

  
   public override void Execute()
   {
        DialogueController.Instanse.StartDialogue(_dialogueID);
   }
}
   

