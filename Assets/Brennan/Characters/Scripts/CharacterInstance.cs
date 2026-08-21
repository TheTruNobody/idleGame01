using System;
using UnityEngine;

[Serializable]
public class CharacterInstance
{
    public string InstanceID;

    public CharacterData CharacterData;

    // Progression
    public int Level;
    public int Experience;

    // Future systems
    public int Ascension;
    public int SkillLevel;

    public CharacterInstance(CharacterData data)
    {
        InstanceID = Guid.NewGuid().ToString();

        CharacterData = data;

        Level = 1;
        Experience = 0;

        Ascension = 0;
        SkillLevel = 1;
    }
    
    public void AddExperience(int amount)
    {
        Experience += amount;

        while (Experience >= GetRequiredExperience())
        {
            Experience -= GetRequiredExperience();
            Level++;
        }
    }

    public int GetRequiredExperience()
    {
        return Level * 100;
    }
}