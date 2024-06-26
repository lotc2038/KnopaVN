using UnityEngine;


public class AddCharacterStep : Step
{
    private string characterName;
    private Vector3 position;

    public AddCharacterStep(string characterName, Vector3 position)
    {
        this.characterName = characterName;
        this.position = position;
    }

    public override void Execute()
    {
      //  CharactersController.Instance.AddCharacter(characterName, position);
    }
}


