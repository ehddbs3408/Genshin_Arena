using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {

        if (_aiActionData.attack) return;

        _aiActionData.attack = true;
        _aimovementData.direction = Vector3.zero;
        _aimovementData.pointOfInterest = _enemyBrain.target.position;
        Debug.Log("Attack!");
        _enemyBrain.Attack();
        _enemyBrain.Move(_aimovementData.direction, _aimovementData.pointOfInterest);
    }
}
