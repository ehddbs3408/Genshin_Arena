using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedPlate : MonoBehaviour
{
    [SerializeField]
    private LayerMask _enemyMask;

    private SpriteRenderer _spriteRenderer;

    private float _attackRange;
    private int _damage;
    private GameObject _dealer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Init(10,1,null,LayerMask.GetMask("Enemy"));
    }
    public void Init(float attackRange,int damege,GameObject dealer,LayerMask mask )
    {
        gameObject.SetActive(false);
        _attackRange = attackRange;
        _damage = damege;
        _dealer = dealer;
        _enemyMask = mask;
    }

    public void Attack()
    {
        gameObject.SetActive(true);
        Collider[] cols = Physics.OverlapSphere(transform.position, _attackRange);
        foreach(Collider col in cols)
        {
            if(col.gameObject.layer == _enemyMask)
            {
                IHittable hit = col.GetComponent<IHittable>();
                hit.OnGethit(_damage, _dealer);
            }
        }

    }
}
