using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyKill
{
    public int wave;
    public int killEnemyCnt;
}


public class EnemyKillJsonData
{
    public List<EnemyKill> enemyKillList;
}
