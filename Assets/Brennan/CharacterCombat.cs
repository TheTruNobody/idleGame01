using UnityEngine;

public class CharacterCombat : CombatUnit
{
    private CharacterInstance character;

    /// <summary>
    /// Called by CharacterSpawner immediately
    /// after the prefab is instantiated.
    /// </summary>
    public void Initialize(CharacterInstance character)
    {
        this.character = character;

        // TODO:
        // Calculate stats from:
        // CharacterData
        // + Level
        // + Equipment
        // + Buffs

        // Then call:
        //
        // InitializeStats(...)
    }

    /// <summary>
    /// Finds the nearest living enemy.
    ///
    /// Future implementation:
    /// Search all EnemyCombat objects.
    /// Ignore dead enemies.
    /// Return closest.
    /// </summary>
    protected override CombatUnit FindTarget()
    {
        return null;
    }

    /// <summary>
    /// Player units move right.
    /// </summary>
    protected override Vector2 GetMoveDirection()
    {
        return Vector2.right;
    }
}