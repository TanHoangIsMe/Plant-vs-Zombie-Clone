using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelWaveData", menuName = "Scriptable Objects/LevelWaveData")]
public class LevelWaveData : ScriptableObject
{
    public List<EnemyEntry> allEntries;

    [Serializable]
    public class EnemyEntry
    {
        public Enemy enemy;
        public int amount;
        public float appearTime;
        public SpawnPosition spawnPosition;
    }

    public enum Enemy
    {
        ZombieMan,
        ZombieMan1,
        ZombieMan2,
    }

    public enum SpawnPosition
    {
        Lane1,
        Lane2,
        Lane3,
        Lane4,
        Lane5
    }
}
