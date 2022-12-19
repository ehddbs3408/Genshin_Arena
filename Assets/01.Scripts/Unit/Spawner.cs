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

    private int _spawnEnemyCount;
    public int SpawnEnemyCount => _spawnEnemyCount;


    private void Awake()
    {
        _currentSpawnData = _spawnEnemyList[0];
        _spawnEnemyCount = 0;
    }
    private void Update()
    {
        CheckSpawnEnemy();
    }

    public void SetSpawnGruop(string gruopName)
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
    public void SpawnEnemy(bool oneSpawn)
    {
        if(oneSpawn)
        {
            int idx = UnityEngine.Random.Range(0, _spawnPosList.Count);
            SpawnPointEnemy(idx);
        }
        else
        {
            for (int i = 0; i < _spawnPosList.Count; i++)
            {
                SpawnPointEnemy(i);
            }
        }
        
    }
    public void SpawnPointEnemy(int posIdx)
    {
        int enemyMaxIdx = _currentSpawnData.enemyNames.Count;
        int enemyIdx = UnityEngine.Random.Range(0, enemyMaxIdx);
        string path = _currentSpawnData.enemyNames[enemyIdx];

        GameObject go = Managers.Resource.Instantiate(path);
        go.transform.position = _spawnPosList[posIdx].position;
        go.transform.SetParent(gameObject.transform);
        go.SetActive(true);
    }

    public void CheckSpawnEnemy()
    {
        _spawnEnemyCount = transform.childCount;
        Debug.Log(_spawnEnemyCount);
    }
}
