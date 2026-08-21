using System;

[Serializable]
public class ItemStack
{
    public ExpItemData Item;
    public int Amount;

    public ItemStack(
        ExpItemData item,
        int amount)
    {
        Item = item;
        Amount = amount;
    }
}