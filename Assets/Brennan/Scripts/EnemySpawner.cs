using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [Header("Spawn Settings")]
    [SerializeField] private Transform spawnPoint;

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

    public IEnumerator SpawnWave(WaveData wave)
    {
        foreach (EnemySpawn spawn in wave.Enemies)
        {
            for (int i = 0; i < spawn.Amount; i++)
            {
                SpawnEnemy(spawn.Enemy);

                if (spawn.SpawnDelay > 0)
                {
                    yield return new WaitForSeconds(
                        spawn.SpawnDelay);
                }
            }
        }
    }

    private void SpawnEnemy(EnemyData enemyData)
    {
        if (enemyData.Prefab == null)
        {
            Debug.LogWarning(
                enemyData.UnitName +
                " has no prefab assigned!");

            return;
        }

        GameObject obj = Instantiate(
            enemyData.Prefab,
            spawnPoint.position,
            Quaternion.identity);

        EnemyCombat combat =
            obj.GetComponent<EnemyCombat>();

        if (combat != null)
        {
            combat.Initialize(enemyData);
        }
        else
        {
            Debug.LogWarning(
                obj.name +
                " is missing EnemyCombat!");
        }
    }
}