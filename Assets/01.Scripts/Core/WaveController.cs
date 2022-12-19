using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
class WaveData
{
    public string waveName;
    public float waveNextStartTime;
    public float spawnEnemyDelay;
    public bool optionRandomPosSpawn;
    public int waveMaxEnemyCount;
}
public class WaveController : MonoBehaviour
{
    private Spawner _spawner;

    [SerializeField]
    private List<WaveData> _waveDataList;

    private WaveData _currentWaveData;
    private float _spawnTime;
    private int _currentWaveIdx;

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
        _currentWaveData = _waveDataList[0];
    }

    private void Update()
    {
        Wave();
        WaveOverCountEnemy();
    }

    private void Wave()
    {
       // Debug.Log($"{Managers.TimeMa.playTime} : ");
        if(_currentWaveData.waveNextStartTime <= Managers.TimeMa.playTime)
        {
            NextWave();
        }

        if(Managers.TimeMa.playTime > _spawnTime + _currentWaveData.spawnEnemyDelay)
        {
            _spawner.SpawnEnemy(_currentWaveData.optionRandomPosSpawn);
            _spawnTime = Managers.TimeMa.playTime;
        }
    }

    private void WaveOverCountEnemy()
    {
        //Debug.Log($"{_spawner.SpawnEnemyCount} : {_currentWaveData.waveMaxEnemyCount}");
        if(_spawner.SpawnEnemyCount >= _currentWaveData.waveMaxEnemyCount)
        {
            GameScene scene = Managers.Scene.CurrentScene as GameScene;
            scene.GameOver();
        }
    }
    private void NextWave()
    {
        if (_currentWaveIdx + 1>= _waveDataList.Count) return;

        Debug.Log("NextWave");

        _currentWaveIdx++;
        _currentWaveData = _waveDataList[_currentWaveIdx];

        _spawner.SetSpawnGruop(_currentWaveData.waveName);
    }
}
