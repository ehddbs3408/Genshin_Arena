using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Rigidbody _rigid;
    private Weapon _weapon;

    [SerializeField]
    private string spriteRendererPath;
    private AgentSpriteRenderer _agentSpriteRenderer;
    public AgentSpriteRenderer AgentSprite => _agentSpriteRenderer;

    [SerializeField]
    private string animatorPath;
    private AgentAnimation _agentAnimator;
    public AgentAnimation AgentAnimator => _agentAnimator;

    private StaminaBar _staminaBar;
    private float _maxStamina;
    private float _stamina;


    #region Interface
    public override void OnDead()
    {
        Debug.Log(gameObject.name + " : Dead");
        _agentMovement.MovementStopFlag();
        _agentSpriteRenderer.SpriteRendererFlag();
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
        float stunPower = power - _unitData.stunResistance < 0 ? 0 : power - _unitData.stunResistance;
        if(stunPower != 0)
        {
            duration = duration * (stunPower / 100.0f);
            Debug.Log("stop time : " + duration);
        }

        _agentMovement.StopMovement(duration);
    }
    #endregion

    protected override void Awake()
    {
        Health = _unitData.maxHp;
        _rigid = GetComponent<Rigidbody>();
        _weapon = transform.Find("Weapon").GetComponent<Weapon>();
        _agentMovement = GetComponent<AgentMovement>();
        _agentSpriteRenderer = transform.Find(spriteRendererPath).GetComponent<AgentSpriteRenderer>();
        _agentAnimator = transform.Find(animatorPath).GetComponent<AgentAnimation>();

        _staminaBar = transform.Find("StaminaBar").GetComponent<StaminaBar>();
        _maxStamina = _stamina =_unitData.maxStamina ;
    }

    private void Update()
    {
        StaminaHealth();
    }

    public void StaminaHealth()
    {
        _stamina += Time.deltaTime * 10;
        _stamina = _stamina >= _maxStamina ? _maxStamina : _stamina;
        _staminaBar.ChangeStaminaBar(_stamina / _maxStamina);
    }

    public void Dash(Vector3 vec)
    {
        if (_stamina < 20) return;

        _stamina = _stamina - 20 > 0 ? _stamina - 20 : 0;
        _staminaBar.ChangeStaminaBar(_stamina / _maxStamina);
        _agentMovement.Dash(vec,20);
    }

    public override void OnAttack()
    {
        _weapon.OnAttack(gameObject);
    }
}
