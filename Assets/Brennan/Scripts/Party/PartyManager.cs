using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public static PartyManager Instance;

    private const int PARTY_SIZE = 4;

    private List<CharacterInstance> party =
        new List<CharacterInstance>(PARTY_SIZE);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            for (int i = 0; i < PARTY_SIZE; i++)
            {
                party.Add(null);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<CharacterInstance> GetParty()
    {
        return party;
    }

    public CharacterInstance GetPartyMember(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= PARTY_SIZE)
            return null;

        return party[slotIndex];
    }

    public bool IsInParty(CharacterInstance character)
    {
        return party.Contains(character);
    }

    public void SetPartyMember(
        int slotIndex,
        CharacterInstance character)
    {
        if (slotIndex < 0 || slotIndex >= PARTY_SIZE)
            return;

        int existingIndex =
            party.IndexOf(character);

        if (existingIndex >= 0)
        {
            party[existingIndex] = null;
        }

        party[slotIndex] = character;
    }

    public void RemovePartyMember(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= PARTY_SIZE)
            return;

        party[slotIndex] = null;
    }
}