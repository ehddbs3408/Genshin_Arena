using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDurationDecision : AIDecision
{
    [SerializeField]
    private float durationTime;
    private float deltaTime = 0;
    public override bool MakeADecision()
    {
        if(deltaTime >= durationTime)
        {
            deltaTime = 0;
            return true;
        }
        deltaTime += Time.deltaTime;
        return false;    
    }
}
