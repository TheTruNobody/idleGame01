using System;
using UnityEngine;

[Serializable]
public class EnemySpawn
{
    [Header("Enemy")]

    [SerializeField]
    private EnemyData enemy;

    [SerializeField]
    private int amount = 1;

    [SerializeField]
    private float spawnDelay = 0f;

    public EnemyData Enemy => enemy;

    public int Amount => amount;

    public float SpawnDelay => spawnDelay;
}