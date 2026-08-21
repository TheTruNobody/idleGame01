using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlotUI : MonoBehaviour
{
    [SerializeField] private Image portrait;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text rarityText;

    [SerializeField] private GameObject selectedIndicator;
    [SerializeField] private GameObject partyIndicator;

    private CharacterInstance character;
    
    //initializes a slot with a specific character
    public void Initialize(CharacterInstance characterData)
    {
        character = characterData;

        portrait.sprite =
            character.CharacterData.Portrait;

        nameText.text =
            character.CharacterData.UnitName;

        levelText.text =
            "Lv. " + character.Level;

        rarityText.text =
            character.CharacterData.Rarity.ToString();

        RefreshSelection();
        RefreshPartyStatus();
    }

    //called when player clicks on specific char slot
    public void OnClick()
    {
        //selects char for party assignment
        if (PartySelectionManager.Instance != null)
        {
            PartySelectionManager.Instance
                .SelectCharacter(character);
        }
        //display char details panel (not being used yet)
        if (CharacterDetailsUI.Instance != null)
        {
            CharacterDetailsUI.Instance
                .Show(character);
        }
        //refreshes all inv slot visuals so selected state updates
        FindFirstObjectByType<InventoryUI>()
            ?.RefreshSelectionVisuals();
    }
    //updates the selected indicator
    public void RefreshSelection()
    {
        //check if this char is currently selected
        bool isSelected =
            PartySelectionManager.Instance
                .SelectedCharacter == character;
        //show or hide the selection indicator
        if (selectedIndicator != null)
        {
            selectedIndicator.SetActive(isSelected);
        }
    }
    //updates party indicator
    public void RefreshPartyStatus()
    {
        //check if this char is currently assigned to the active party
        bool inParty =
            PartyManager.Instance
                .IsInParty(character);
        //show or hide the party indicator
        if (partyIndicator != null)
        {
            partyIndicator.SetActive(inParty);
        }
    }
    
    public void OnConvertButton()
    {
        InventoryManager.Instance
            .ConvertCharacter(character);

        FindFirstObjectByType<InventoryUI>()
            ?.PopulateInventory();
    }
}