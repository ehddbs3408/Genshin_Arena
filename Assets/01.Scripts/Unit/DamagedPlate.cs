using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedPlate : MonoBehaviour
{
    [SerializeField]
    private LayerMask _enemyMask;

    private SpriteRenderer _spriteRenderer;

    private float _attackRange;
    private float _attackDelay;
    private int _damage;
    private GameObject _dealer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Init(10,1,0.5f,null,LayerMask.GetMask("Player"));
    }
    public void Init(float attackRange,int damege,float delay,GameObject dealer,LayerMask mask )
    {
        _spriteRenderer.enabled = false;
        _attackRange = attackRange;
        _damage = damege;
        _attackDelay = delay;
        _dealer = dealer;
        _enemyMask = mask;
    }

    public void Attack()
    {
        StartCoroutine(AttackCroutine(_attackDelay));
    }

    private IEnumerator AttackCroutine(float duration)
    {
        VoidAttackRange(true);
        yield return new WaitForSeconds(duration);
        VoidAttackRange(false);
        CheckColliderInEnemy();
    }

    private void CheckColliderInEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _attackRange);
        foreach (Collider col in cols)
        {
            if (col.gameObject.layer == _enemyMask)
            {
                IHittable hit = col.GetComponent<IHittable>();
                hit.OnGethit(_damage, _dealer);
            }
        }
    }

    private void VoidAttackRange(bool value)
    {
        _spriteRenderer.enabled = value;
    }
}
