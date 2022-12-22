using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyUnit : MonoBehaviour, IHittable, IKnockBack, IStun
{
    [SerializeField]
    protected UnitDataSO _unitData;

    protected bool _isDead = false;

    protected AgentMovement _agentMovement;
    public AgentMovement AgentMovement => _agentMovement;
    protected EnemyAnimation _animator;
    protected UnitAttack _unitAttack;
    protected BoxCollider _boxCol;
    protected AIHeader _header;

    public Transform _basePosition = null;

    [SerializeField]
    protected bool _isActive = true;

    #region Hittable
    public int Health { get; set; }

    public abstract void OnDead();
    public abstract void OnAttack();

    public virtual void OnGethit(int damaged, GameObject dealer)
    {

        Debug.Log($"hit : {gameObject.name}");
        Health -= damaged;

        if (Health <= 0)
        {
            OnDead();
        }
        Collider other;
        IHittable hit = other.transform.GetComponent<IHittable>();
        hit.OnGethit(100, gameObject);
    }
    #endregion

    protected virtual void Awake()
    {
        _agentMovement = GetComponent<AgentMovement>();
        _animator = transform.Find("VisualSprite").GetComponent<EnemyAnimation>();
        _unitAttack = GetComponent<UnitAttack>();
        _boxCol = GetComponent<BoxCollider>();
        _header = GetComponent<AIHeader>();
    }

    public void Init()
    {
        Health = _unitData.maxHp;
        _isActive = false;
        _isDead = false;
    }

    public virtual void OnGetKnockBack(Vector3 dir, float power, float duration, GameObject dealer = null)
    {
        Debug.Log("KnockBack");
        //_agentMovement.StopMovement(duration);
        Vector3 vec = new Vector3(dir.x, 0, dir.z);
        _agentMovement.Dash(vec, power);

    }

    public virtual void OnGetStun(float power, float duration)
    {

    }
}
