using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack : MonoBehaviour
{
    [SerializeField]
    protected UnitAttackDataSO _attackDataSO;

    protected bool _isAttackFlag = true;

     protected virtual void OnAttack(IHittable hit)
    {
        if (_isAttackFlag == false) return;

        hit.OnGethit(_attackDataSO.damage, gameObject);
        StartCoroutine(AttackDelay(_attackDataSO.attackDelay));
    }

    protected IEnumerator AttackDelay(float duration)
    {
        _isAttackFlag = false;
        yield return new WaitForSeconds(duration);
        _isAttackFlag = true;
    }

}
