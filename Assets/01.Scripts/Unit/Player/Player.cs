using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Rigidbody _rigid;
    private Weapon _weapon;

    private AgentMovement _agentMovement;
    [SerializeField]
    private string spriteRendererPath;
    private AgentSpriteRenderer _agnetSpriteRenderer;
    [SerializeField]
    private string animatorPath;
    private AgentAnimation _agnetAnimator;


    #region Interface
    public override void OnDead()
    {
        Debug.Log(gameObject.name + " : Dead");
        _agentMovement.MovementStopFlag();
        _agnetSpriteRenderer.SpriteRendererFlag();
    }

    public override void OnGethit(int damaged, GameObject dealer)
    {
        Debug.Log(this.gameObject.name + " : " + damaged +" Damage");
        base.OnGethit(damaged, dealer);
    }

    public override void OnGetKnockBack(Vector3 dir, float power, float duration, GameObject dealer = null)
    {
        _rigid.AddForce(dir.normalized * power,ForceMode.Impulse);
    }

    public override void OnGetStun(float power, float duration)
    {
        float stunPower = power - unitData.stunResistance < 0 ? 0 : power - unitData.stunResistance;
        if(stunPower != 0)
        {
            duration = duration * (stunPower / 100.0f);
            Debug.Log("stop time : " + duration);
        }

        _agentMovement.StopMovement(duration);
    }
    #endregion

    private void Awake()
    {
        Health = unitData.maxHp;
        _rigid = GetComponent<Rigidbody>();
        _weapon = GetComponent<Weapon>();
        _agentMovement = GetComponent<AgentMovement>();
        _agnetSpriteRenderer = transform.Find(spriteRendererPath).GetComponent<AgentSpriteRenderer>();
        _agnetAnimator = transform.Find(animatorPath).GetComponent<AgentAnimation>();
    }

    public void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 10f);

        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        foreach(Collider col in cols)
        {
            if(_weapon.OnAttack(vec, col.gameObject.transform.position))
            {
                IHittable hit = col.gameObject.GetComponent<IHittable>();
                hit.OnGethit(10,gameObject);
            }
        }
        
    }
}
