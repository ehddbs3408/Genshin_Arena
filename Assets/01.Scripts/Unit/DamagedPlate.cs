using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedPlate : MonoBehaviour
{
    private LayerMask _enemyMask;

    private SpriteRenderer _spriteRenderer;
    private Collider _col;

    private float _attackRange;
    private float _attackDelay;
    private int _damage;
    private GameObject _dealer;

    private bool _isOnAttackFlag = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider>();
    }
    private void Start()
    {
        VoidAttackRange(false);
    }
    public void Init(float attackRange,int damege,float delay,GameObject dealer,LayerMask mask,Vector3 pos)
    {
        pos.y = 0;
        transform.position = pos;
        _spriteRenderer.enabled = false;
        _attackRange = attackRange;
        _damage = damege;
        _attackDelay = delay;
        _dealer = dealer;
        _enemyMask = mask;
        Attack();
    }

    public void Attack()
    {
        Debug.Log("asd");
        StartCoroutine(AttackCroutine(_attackDelay));
    }

    private IEnumerator AttackCroutine(float duration)
    {
        VoidAttackRange(true);
        
        yield return new WaitForSeconds(duration);
        _isOnAttackFlag = true;
        VoidAttackRange(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_isOnAttackFlag) return;

        Debug.Log("PlayerAttack!");
        _isOnAttackFlag = false;
        IHittable hit = other.GetComponent<IHittable>();
        hit.OnGethit(_damage, _dealer);
    }

    private void VoidAttackRange(bool value)
    {
        _spriteRenderer.enabled = value;
    }
}
