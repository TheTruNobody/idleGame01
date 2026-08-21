using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Battle",
    menuName = "Battle/Battle")]
public class BattleData : ScriptableObject
{
    [Header("Battle")]

    [SerializeField]
    private string battleName;

    [SerializeField]
    private List<WaveData> waves =
        new List<WaveData>();

    public string BattleName => battleName;

    public IReadOnlyList<WaveData> Waves => waves;
}