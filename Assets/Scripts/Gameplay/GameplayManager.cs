using System.Collections;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private EnemyDatabase enemyDatabase;
    [SerializeField] private SpawnPositionDatabase spawnPositionDatabase;
    [SerializeField] private LevelWaveData levelWaveData;

    private void Start()
    {
        StartCoroutine(StartMatch());                         
    }

    private IEnumerator StartMatch()
    {
        float passedTime = 0f;
        int spawnedEnemy = 0;
       
        while (spawnedEnemy < levelWaveData.allEntries.Count)
        {
            yield return null;

            passedTime += Time.deltaTime;
            Debug.Log(passedTime);

            if (passedTime >= levelWaveData.allEntries[spawnedEnemy].appearTime)
            {
                Instantiate(
                    GetEnemyPrefab((int)levelWaveData.allEntries[spawnedEnemy].enemy),
                    GetSpawnPosition((int)levelWaveData.allEntries[spawnedEnemy].spawnPosition),
                    Quaternion.identity);

                spawnedEnemy++;
            }
        }

        Debug.Log("finish");
    }

    private GameObject GetEnemyPrefab(int index)
    {
        return enemyDatabase.enemyPrefab[index];
    }

    private Vector3 GetSpawnPosition(int lane)
    {
        return spawnPositionDatabase.position[lane];
    }
}
