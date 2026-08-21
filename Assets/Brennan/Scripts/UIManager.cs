using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private ItemInventoryUI itemInventoryUI;

    [SerializeField] private GameObject lootPanel;
    [SerializeField] private GameObject characterInventoryPanel;
    [SerializeField] private GameObject partyPanel;
    [SerializeField] private GameObject itemInventoryPanel;
    [SerializeField] private GameObject characterDetailPanel;

    private void Awake()
    {
        Instance = this;
        
        characterDetailPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShowLoot();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ShowInventory();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowParty();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowItems();
        }
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (PartySelectionManager.Instance
                    .SelectedCharacter != null)
            {
                ToggleCharacterDetails();
            }
        }
    }

    public void ShowLoot()
    {
        lootPanel.SetActive(true);
        characterInventoryPanel.SetActive(false);
        partyPanel.SetActive(false);
        itemInventoryPanel.SetActive(false);
    }

    public void ShowInventory()
    {
        lootPanel.SetActive(false);
        characterInventoryPanel.SetActive(true);
        partyPanel.SetActive(false);
        itemInventoryPanel.SetActive(false);

        FindFirstObjectByType<InventoryUI>()?.PopulateInventory();
    }

    public void ShowParty()
    {
        lootPanel.SetActive(false);
        characterInventoryPanel.SetActive(false);
        partyPanel.SetActive(true);
        itemInventoryPanel.SetActive(false);

        PartyUI.Instance.RefreshAllSlots();
    }
    
    public void ShowItems()
    {
        lootPanel.SetActive(false);
        characterInventoryPanel.SetActive(false);
        partyPanel.SetActive(false);

        itemInventoryPanel.SetActive(true);

        itemInventoryUI.Populate();
    }

    public void ToggleCharacterDetails()
    {
        characterDetailPanel.SetActive(
            !characterDetailPanel.activeSelf);
    }
}