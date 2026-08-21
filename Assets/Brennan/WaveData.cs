using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Wave",
    menuName = "Battle/Wave")]
public class WaveData : ScriptableObject
{
    [Header("Wave")]

    [SerializeField]
    private string waveName = "Wave";

    [SerializeField]
    private List<EnemySpawn> enemies =
        new List<EnemySpawn>();

    public string WaveName => waveName;

    public IReadOnlyList<EnemySpawn> Enemies => enemies;
}