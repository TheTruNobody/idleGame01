using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private List<CharacterInstance> ownedCharacters =
        new List<CharacterInstance>();
    
    [SerializeField]
    private ExpItemData commonBook;

    [SerializeField]
    private ExpItemData rareBook;

    [SerializeField]
    private ExpItemData epicBook;

    [SerializeField]
    private ExpItemData legendaryBook;

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

    public void AddCharacter(CharacterData characterData)
    {
        CharacterInstance newCharacter =
            new CharacterInstance(characterData);

        ownedCharacters.Add(newCharacter);

        Debug.Log(
            $"Added {characterData.UnitName} to inventory.");
    }

    public List<CharacterInstance> GetCharacters()
    {
        return ownedCharacters;
    }
    
    public void RemoveCharacter(
        CharacterInstance character)
    {
        ownedCharacters.Remove(character);
    }
    
    public void ConvertCharacter(
        CharacterInstance character)
    {
        if (character == null)
            return;

        // Prevent deleting party members
        if (PartyManager.Instance != null &&
            PartyManager.Instance.IsInParty(character))
        {
            Debug.Log(
                "Cannot convert a party member.");
            return;
        }

        ExpItemData reward = null;

        switch (character.CharacterData.Rarity)
        {
            case CharacterRarity.Common:
                reward = commonBook;
                break;

            case CharacterRarity.Rare:
                reward = rareBook;
                break;

            case CharacterRarity.Epic:
                reward = epicBook;
                break;

            case CharacterRarity.Legendary:
                reward = legendaryBook;
                break;
        }

        ownedCharacters.Remove(character);

        if (reward != null)
        {
            ItemInventoryManager.Instance
                .AddItem(reward, 1);
        }

        Debug.Log(
            $"Converted {character.CharacterData.UnitName} " +
            $"into {reward.ItemName}");
    }
    
    public void ApplyExperienceItem(
        CharacterInstance character,
        ExpItemData item,
        int quantity)
    {
        if (character == null)
            return;

        if (!ItemInventoryManager.Instance
                .RemoveItem(item, quantity))
        {
            Debug.Log("Not enough items.");
            return;
        }

        int totalExp =
            item.ExperienceValue * quantity;

        character.AddExperience(totalExp);

        Debug.Log(
            $"{character.CharacterData.UnitName} " +
            $"gained {totalExp} EXP.");
    }
}