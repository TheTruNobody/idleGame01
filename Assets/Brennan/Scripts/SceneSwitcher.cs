using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            UIManager.Instance.ShowLoot();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.Instance.ShowInventory();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            UIManager.Instance.ShowParty();
        }
    }
}