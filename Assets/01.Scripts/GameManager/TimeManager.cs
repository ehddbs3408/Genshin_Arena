using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{
    public float playTime;
    public void Init()
    {
        playTime = 0;
    }
    public void OnUpdate(float delta)
    {
        playTime += delta;
    }

    public void Clear()
    {
        Init();
    }
}
