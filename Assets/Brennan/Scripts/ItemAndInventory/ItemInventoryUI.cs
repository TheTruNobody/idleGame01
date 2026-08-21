using UnityEngine;

public class ItemInventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform contentParent;

    [SerializeField]
    private ItemSlotUI slotPrefab;

    public void Populate()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemStack stack in
                 ItemInventoryManager.Instance
                     .GetItems())
        {
            ItemSlotUI slot =
                Instantiate(
                    slotPrefab,
                    contentParent);

            slot.Initialize(stack);
        }
    }

    private void Start()
    {
        Populate();
    }
}