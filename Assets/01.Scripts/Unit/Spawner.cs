using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
class SpawnData
{
    public string waveName;
    public List<string> enemyNames;
}

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPosList;
    [SerializeField]
    private List<SpawnData> _spawnEnemyList;

    private SpawnData _currentSpawnData;

    private int _spawnIdx;

    private float _timer;

    public void SpawnGruop(string gruopName)
    {
        foreach(SpawnData data in _spawnEnemyList)
        {
            if(data.waveName == gruopName)
            {
                _currentSpawnData = data;
                return;
            }
        }

        Debug.LogError("Not Found Enemy Group");
    }
    public void SpawnEnemy()
    {

    }
    public void SpawnPointEnemy(int posIdx)
    {
        int enemyMaxIdx = _currentSpawnData.enemyNames.Count;
        int enemyIdx = UnityEngine.Random.Range(0, enemyMaxIdx);
        string path = _currentSpawnData.enemyNames[enemyIdx];

        GameObject go = Managers.Resource.Instantiate(path);
        go.transform.position = _spawnPosList[posIdx].position;
        go.SetActive(true);
    }
}
