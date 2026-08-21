using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Gacha/Character")]
public class CharacterData : CombatUnitData
{
    [Header("Character")]

    public CharacterRarity Rarity;
}