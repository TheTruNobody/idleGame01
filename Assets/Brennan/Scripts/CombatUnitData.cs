using UnityEngine;

public abstract class CombatUnitData : ScriptableObject
{
    [Header("General")]

    public string UnitID;

    public string UnitName;

    public Sprite Portrait;

    public GameObject Prefab;

    [Header("Combat Stats")]

    public int MaxHP;

    public int Attack;

    public int Defense;

    public float MoveSpeed = 2f;

    public float AttackRange = 1.5f;

    public float AttackCooldown = 1f;
}