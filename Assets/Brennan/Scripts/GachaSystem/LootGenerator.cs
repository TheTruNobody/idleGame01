using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LootGenerator : MonoBehaviour
{
    // Input field for where the player enters the number of pulls they want
    [SerializeField] private InputField _input;
    // Reference to UI controller that displays the loot results
    [SerializeField] private LootBagController _lootBagController;
    // Reference to loot table containing possible characters
    [SerializeField] private LootTable _lootTable;

    private void Start()
    {
        Debug.Log("_input = " + _input);
        Debug.Log("_lootBagController = " + _lootBagController);
        Debug.Log(
            $"LootGenerator instance ID: {GetInstanceID()}");
    }
    public void OnLootButton()
    {
        //determines how many pulls depending on what the user inputted
        int pullCount = int.Parse(_input.text);

        //temp list to store pulled characters
        List<CharacterData> pulledCharacters = new List<CharacterData>();

        //pull for loop
        for (int i = 0; i < pullCount; i++)
        {
            CharacterData pulledCharacter = _lootTable.GetRandomCharacter();

            // Add to inventory
            InventoryManager.Instance.AddCharacter(pulledCharacter);

            // Save for display
            pulledCharacters.Add(pulledCharacter);
        }

        var results = pulledCharacters
            .GroupBy(character => character)
            .Select(group => new TableRowItem(group.Key, group.Count()))
            .OrderByDescending(row => row.amount)
            .ToList();

        _lootBagController.PopulateTable(results);
    }
}