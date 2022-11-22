using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Rigidbody _rigid;

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
        _agentMovement = GetComponent<AgentMovement>();
        _agnetSpriteRenderer = transform.Find(spriteRendererPath).GetComponent<AgentSpriteRenderer>();
        _agnetAnimator = transform.Find(animatorPath).GetComponent<AgentAnimation>();
    }
}
