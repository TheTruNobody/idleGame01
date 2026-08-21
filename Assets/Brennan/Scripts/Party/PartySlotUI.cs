using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PartySlotUI :
    MonoBehaviour,
    IPointerClickHandler
{
    [SerializeField] private int slotIndex;

    [SerializeField] private Image portrait;
    [SerializeField] private TMP_Text nameText;

    public void OnClick()
    {
        CharacterInstance selected =
            PartySelectionManager.Instance
                .SelectedCharacter;

        if (selected == null)
            return;

        PartyManager.Instance
            .SetPartyMember(slotIndex, selected);

        PartySelectionManager.Instance
            .ClearSelection();

        PartyUI.Instance
            .RefreshAllSlots();

        FindFirstObjectByType<InventoryUI>()
            ?.RefreshSelectionVisuals();
    }

    public void OnRightClick()
    {
        Debug.Log("Right click detected on slot " + slotIndex);
        
        PartyManager.Instance
            .RemovePartyMember(slotIndex);

        PartyUI.Instance
            .RefreshAllSlots();
    }

    public void Refresh()
    {
        CharacterInstance character =
            PartyManager.Instance
                .GetPartyMember(slotIndex);

        if (character == null)
        {
            portrait.enabled = false;
            nameText.text = "Empty";
            return;
        }

        portrait.enabled = true;

        portrait.sprite =
            character.CharacterData.Portrait;

        nameText.text =
            character.CharacterData.UnitName;
    }

    public void OnPointerClick(
        PointerEventData eventData)
    {
        if (eventData.button ==
            PointerEventData.InputButton.Left)
        {
            OnClick();
        }

        if (eventData.button ==
            PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
}