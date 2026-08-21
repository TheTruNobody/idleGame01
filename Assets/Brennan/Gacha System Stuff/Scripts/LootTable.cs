using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//LootTable asset for creation
[CreateAssetMenu(fileName = "CharacterLootTable", menuName = "Gacha/Character Loot Table")]
public class LootTable : ScriptableObject
{
    //li8st of all char, and weights
    [SerializeField] private List<CharacterLootEntry> _characters;

    //tracks if loot table is initialized
    [System.NonSerialized]
    private bool isInitialized = false;

    //sum of all char weights in the list
    private float _totalWeight;

    //calculates total weight of the loot table
    private void Initialize()
    {
        if (!isInitialized)
        {
            //adds weight
            _totalWeight = _characters.Sum(character => character.weight);
            //marks table as init
            isInitialized = true;
        }
    }
    
    //returns a randomly selected char based on weight
    public CharacterData GetRandomCharacter()
    {
        Initialize();

        //roll a random number between 0 and the total weight
        float diceRoll = Random.Range(0f, _totalWeight);

        //check each character entry in the table
        foreach (var character in _characters)
        {
            //if roll falls within char weight range, return char
            if (character.weight >= diceRoll)
            {
                return character.characterData;
            }
            //otherwise subtract weight and keep checking
            diceRoll -= character.weight;
        }
        //last check incase of edge case, should not happen unless table is empty
        //or invalid weight values
        throw new System.Exception("Character generation failed!");
    }
}