using UnityEngine;

public class PartySelectionManager : MonoBehaviour
{
    public static PartySelectionManager Instance;

    public CharacterInstance SelectedCharacter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectCharacter(CharacterInstance character)
    {
        SelectedCharacter = character;

        Debug.Log(
            "Selected: " +
            character.CharacterData.UnitName);
    }

    public void ClearSelection()
    {
        SelectedCharacter = null;

        Debug.Log("Selection Cleared");
    }
}