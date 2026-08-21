using UnityEngine;

[CreateAssetMenu(
    fileName = "ExpItem",
    menuName = "Items/EXP Item")]
public class ExpItemData : ScriptableObject
{
    public string ItemID;
    public string ItemName;

    public Sprite Icon;

    public int ExperienceValue;
}