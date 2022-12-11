using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        _aiActionData.attack = false;
        Vector3 direction = _enemyBrain.target.position - transform.position;
        _aimovementData.direction = new Vector3(direction.x, 0, direction.z).normalized;
        _aimovementData.pointOfInterest = _enemyBrain.target.position;
        Debug.Log("Chase");
        _enemyBrain.Move(_aimovementData.direction, _aimovementData.pointOfInterest);
    }
}
