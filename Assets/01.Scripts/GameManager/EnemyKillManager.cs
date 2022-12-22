using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillManager
{
    EnemyKillJsonData list;
    EnemyKill _currentKillData;


    public void Init()
    {
        list = new EnemyKillJsonData();
        StartWave();
    }
    public void GameOver()
    {
        list.enemyKillList.Add(_currentKillData);
        string json = DataManager.ObjectToJson(list);
        DataManager.SaveJsonFile(Application.dataPath + "/SAVE/Wave", "KillData", json);
    }
    public void StartWave()
    {
        _currentKillData = new EnemyKill();
        _currentKillData.killEnemyCnt = 0;
        _currentKillData.wave = 1;
    }

    public void EndWave(int nextWaveIdx)
    {
        list.enemyKillList.Add(_currentKillData);
        _currentKillData = new EnemyKill();
        _currentKillData.killEnemyCnt = 0;
        _currentKillData.wave = nextWaveIdx;
    }

    public void AddKillCnt()
    {
        _currentKillData.killEnemyCnt++;
    }
    public void Clear()
    {
        list = new EnemyKillJsonData();
    }
}
