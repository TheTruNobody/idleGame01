using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryManager : MonoBehaviour
{
    public static ItemInventoryManager Instance;

    private List<ItemStack> items =
        new List<ItemStack>();

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

    public void AddItem(
        ExpItemData item,
        int amount)
    {
        ItemStack stack =
            items.Find(i => i.Item == item);

        if (stack != null)
        {
            stack.Amount += amount;
        }
        else
        {
            items.Add(
                new ItemStack(item, amount));
        }
    }

    public List<ItemStack> GetItems()
    {
        return items;
    }
    
    public bool RemoveItem(
        ExpItemData item,
        int amount)
    {
        ItemStack stack =
            items.Find(i => i.Item == item);

        if (stack == null)
            return false;

        if (stack.Amount < amount)
            return false;

        stack.Amount -= amount;

        if (stack.Amount <= 0)
        {
            items.Remove(stack);
        }

        return true;
    }
}