using UnityEngine;

public class CharacterEnhancementUI : MonoBehaviour
{
    public void OnUseSelectedItem()
    {
        CharacterInstance character =
            PartySelectionManager.Instance
                .SelectedCharacter;

        ItemStack stack =
            ItemSelectionManager.Instance
                .SelectedItem;

        if (character == null)
        {
            Debug.Log("No character selected.");
            return;
        }

        if (stack == null)
        {
            Debug.Log("No item selected.");
            return;
        }

        InventoryManager.Instance
            .ApplyExperienceItem(
                character,
                stack.Item,
                1);

        CharacterDetailsUI.Instance
            ?.Show(character);

        FindFirstObjectByType<ItemInventoryUI>()
            ?.Populate();
    }
}