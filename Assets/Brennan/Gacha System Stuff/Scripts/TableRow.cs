using UnityEngine;
using UnityEngine.UI;

public class TableRow : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _characterNameText;
    [SerializeField] private Text _weightText;
    [SerializeField] private Text _amountText;

    public void Init(TableRowItem rowItem)
    {
        if (rowItem.sprite != null)
        {
            _image.sprite = rowItem.sprite;
        }

        _characterNameText.text = rowItem.characterName;
        _weightText.text = rowItem.rarity.ToString();
        _amountText.text = rowItem.amount.ToString();
    }
}

public class TableRowItem
{
    public Sprite sprite;
    public string characterName;
    public CharacterRarity rarity;
    public int amount;

    public TableRowItem(CharacterData character, int pullAmount)
    {
        sprite = character.Portrait;
        characterName = character.UnitName;
        rarity = character.Rarity;
        amount = pullAmount;
    }
}