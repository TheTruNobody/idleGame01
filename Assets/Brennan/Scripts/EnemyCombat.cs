using UnityEngine;

public class EnemyCombat : CombatUnit
{
    private EnemyData enemy;

    /// <summary>
    /// Called by EnemySpawner immediately
    /// after the prefab is instantiated.
    /// </summary>
    public void Initialize(EnemyData enemy)
    {
        this.enemy = enemy;

        // TODO:
        // Read stats directly from EnemyData.
        //
        // Then call:
        //
        // InitializeStats(...)
    }

    /// <summary>
    /// Finds the nearest living player character.
    /// </summary>
    protected override CombatUnit FindTarget()
    {
        return null;
    }

    /// <summary>
    /// Enemy units move left.
    /// </summary>
    protected override Vector2 GetMoveDirection()
    {
        return Vector2.left;
    }
}