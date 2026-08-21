using UnityEngine;

public class PartyUI : MonoBehaviour
{
    public static PartyUI Instance;

    [SerializeField] private PartySlotUI[] partySlots;

    private void Awake()
    {
        Instance = this;
    }

    public void RefreshAllSlots()
    {
        foreach (PartySlotUI slot in partySlots)
        {
            slot.Refresh();
        }
    }
}