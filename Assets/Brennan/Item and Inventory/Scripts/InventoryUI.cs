using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform contentParent;
    [SerializeField] private CharacterSlotUI slotPrefab;

    private readonly List<CharacterSlotUI> slots =
        new List<CharacterSlotUI>();

    private void Start()
    {
        PopulateInventory();
    }
    //Creates the inventory display from the player's characters
    public void PopulateInventory()
    {
        //Clear the list of slot ref
        slots.Clear();
        //remove all existing UI slot objects
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        //create a slot for every char in the inventory
        foreach (CharacterInstance character
                 in InventoryManager.Instance.GetCharacters())
        {
            Debug.Log(
                "Creating slot for: " +
                character.CharacterData.UnitName);
            //create a new slot under the content parent
            CharacterSlotUI slot =
                Instantiate(slotPrefab, contentParent);
            //fill the slot with this character's data
            slot.Initialize(character);
            //store the slot ref for later updates
            slots.Add(slot);
        }
    }
    //updates all slot visuals
    public void RefreshSelectionVisuals()
    {
        foreach (CharacterSlotUI slot in slots)
        {
            //update whether this slot is selected
            slot.RefreshSelection();
            //update whether this character is in the party
            slot.RefreshPartyStatus();
        }
    }
}