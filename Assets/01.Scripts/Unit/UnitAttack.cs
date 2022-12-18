using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack : MonoBehaviour
{
    [SerializeField]
    protected UnitAttackDataSO _attackDataSO;
    [SerializeField]
    protected LayerMask _enemyLayer;

    protected bool _isAttackFlag = true;

    protected virtual void Awake()
    {
    }

    public virtual void OnAttack()
    {
        if (_isAttackFlag == false) return;

        IHittable hit = Managers.PlayerTrm.GetComponent<IHittable>();
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
