using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text amountText;
    
    private ItemStack stack;

    public void Initialize(ItemStack itemStack)
    {
        stack = itemStack;

        icon.sprite = stack.Item.Icon;

        itemName.text =
            stack.Item.ItemName;

        amountText.text =
            "x" + stack.Amount;
    }
    
    public void OnClick()
    {
        ItemSelectionManager.Instance
            .SelectItem(stack);

        Debug.Log(
            "Selected item: " +
            stack.Item.ItemName);
    }
}