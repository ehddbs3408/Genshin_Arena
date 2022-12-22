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
        _header.isDead = true;
        _animator.OnTriggerDeadAnimation();
        StartCoroutine(DeadCoruotine());
    }

    private IEnumerator DeadCoruotine()
    {
        yield return new WaitForSeconds(1f);
        Managers.Kill.AddKillCnt();
        Managers.Resource.Destroy(gameObject);
    }
}
