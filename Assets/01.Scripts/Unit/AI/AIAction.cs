using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIActionData _aiActionData;
    protected AIMovementData _aimovementData;
    protected AIHeader _enemyBrain;

    protected virtual void Awake()
    {
        _aiActionData = transform.GetComponentInParent<AIActionData>();
        _aimovementData = transform.GetComponentInParent<AIMovementData>();
        _enemyBrain = transform.GetComponentInParent<AIHeader>();

        ChidAwake();
    }
    protected virtual void ChidAwake()
    {
        //
    }
    public abstract void TakeAction();

}
