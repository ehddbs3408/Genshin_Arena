using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
class WaveData
{
    public string waveName;
    public float waveStartTime;
    public float spawnEnemyDelay;
    public bool optionRandomPosSpawn;
    public bool waveMaxEnemyCount;
}
public class WaveController : MonoBehaviour
{
    private Spawner _spawner;

    [SerializeField]
    private List<WaveData> _waveDataList;

    public int enemyCount;

    private float _waveNextWaveTime;
    private int _currentWaveIdx;
    private float _spawnDelay;
    private float _spawnTime;
    private bool _waveOption;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if (_waveDataList[0] == null) return;

        _currentWaveIdx = 0;
        _spawnDelay = _waveDataList[0].spawnEnemyDelay;
        _waveOption = _waveDataList[0].optionRandomPosSpawn;

        if (_waveDataList[1] == null) return;
        _waveNextWaveTime = _waveDataList[1].waveStartTime;
    }

    private void Update()
    {
        Wave();
    }

    private void Wave()
    {
        Debug.Log($"{Managers.TimeMa.playTime} : ");
        if(_waveNextWaveTime<=Managers.TimeMa.playTime)
        {
            NextWave();
        }

        if(Managers.TimeMa.playTime > _spawnTime + _spawnDelay)
        {
            _spawner.SpawnEnemy(_waveOption);
            _spawnTime = Managers.TimeMa.playTime;
        }
       
    }
    private void NextWave()
    {
        if (_currentWaveIdx + 1>= _waveDataList.Count) return;

        Debug.Log("NextWave");

        _currentWaveIdx++;
        _waveOption = _waveDataList[_currentWaveIdx].optionRandomPosSpawn;
        _waveNextWaveTime = _waveDataList[_currentWaveIdx].waveStartTime;
        _spawnDelay = _waveDataList[_currentWaveIdx].spawnEnemyDelay;

        _spawner.SetSpawnGruop(_waveDataList[_currentWaveIdx].waveName);
    }
}
