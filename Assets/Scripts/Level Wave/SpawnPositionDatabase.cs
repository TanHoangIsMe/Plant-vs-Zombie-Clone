using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPositionDatabase", menuName = "Scriptable Objects/SpawnPositionDatabase")]
public class SpawnPositionDatabase : ScriptableObject
{
    public List<Vector3> position;    
}
