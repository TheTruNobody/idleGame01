using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public static CharacterSpawner Instance;

    [Header("Spawn Settings")]
    [SerializeField] private Transform[] spawnPoints;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnParty()
    {
        var party = PartyManager.Instance.GetParty();

        for (int i = 0; i < party.Count; i++)
        {
            CharacterInstance character = party[i];

            if (character == null)
                continue;

            if (character.CharacterData.Prefab == null)
            {
                Debug.LogWarning(
                    character.CharacterData.UnitName +
                    " has no prefab assigned!");

                continue;
            }

            GameObject obj = Instantiate(
                character.CharacterData.Prefab,
                spawnPoints[i].position,
                Quaternion.identity);

            CharacterCombat combat =
                obj.GetComponent<CharacterCombat>();

            if (combat != null)
            {
                combat.Initialize(character);
            }
            else
            {
                Debug.LogWarning(
                    obj.name +
                    " is missing CharacterCombat!");
            }
        }
    }
}