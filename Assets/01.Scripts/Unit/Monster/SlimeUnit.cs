using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeUnit : EnemyUnit
{

    public override void OnAttack()
    {
        _animator.OnTriggerAttackAnimation();
    }

    public override void OnDead()
    {
        _animator.OnTriggerDeadAnimation();
    }
}
