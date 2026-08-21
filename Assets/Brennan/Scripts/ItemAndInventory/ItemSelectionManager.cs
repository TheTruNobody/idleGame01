using UnityEngine;

public class ItemSelectionManager : MonoBehaviour
{
    public static ItemSelectionManager Instance;

    public ItemStack SelectedItem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectItem(ItemStack item)
    {
        SelectedItem = item;

        Debug.Log(
            "Selected item: " +
            item.Item.ItemName);
    }

    public void ClearSelection()
    {
        SelectedItem = null;
    }
}