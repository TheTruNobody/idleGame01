using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailsUI : MonoBehaviour
{
    public static CharacterDetailsUI Instance;

    [SerializeField] private Image portrait;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text rarityText;
    
    [SerializeField]
    private Slider experienceBar;

    [SerializeField]
    private TMP_Text experienceText;

    private void Awake()
    {
        Instance = this;
    }

    public void Show(CharacterInstance character)
    {
        portrait.sprite =
            character.CharacterData.Portrait;

        nameText.text =
            character.CharacterData.UnitName;

        levelText.text =
            "Lv. " + character.Level;

        rarityText.text =
            character.CharacterData.Rarity.ToString();
        
        experienceBar.maxValue =
            character.GetRequiredExperience();

        experienceBar.value =
            character.Experience;

        experienceText.text =
            character.Experience +
            " / " +
            character.GetRequiredExperience();
    }
    
}