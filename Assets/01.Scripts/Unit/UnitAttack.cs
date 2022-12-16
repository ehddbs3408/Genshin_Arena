using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack : MonoBehaviour
{
    [SerializeField]
    protected UnitAttackDataSO _attackDataSO;
    [SerializeField]
    protected LayerMask _enemyLayer;

    protected DamagedPlate _damagedPlate;

    protected bool _isAttackFlag = true;

    protected virtual void Awake()
    {
        _damagedPlate = transform.Find("Plate").GetComponent<DamagedPlate>();
    }

    protected virtual void OnAttack(IHittable hit)
    {
        if (_isAttackFlag == false) return;

        //hit.OnGethit(_attackDataSO.damage, gameObject);
        _damagedPlate.Init(_attackDataSO.attackRange, _attackDataSO.damage, _attackDataSO.attackDelay, gameObject, _enemyLayer,transform.position);
        StartCoroutine(AttackDelay(_attackDataSO.attackDelay));
    }

    protected IEnumerator AttackDelay(float duration)
    {
        _isAttackFlag = false;
        yield return new WaitForSeconds(duration);
        _isAttackFlag = true;
    }

}
