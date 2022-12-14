using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private Animator _ani;

    private readonly int _HashRun = Animator.StringToHash("Run");
    private readonly int _HashAttack = Animator.StringToHash("Attack");
    private readonly int _HashDead = Animator.StringToHash("Dead");
    protected virtual void Awake()
    {
        _ani = GetComponent<Animator>();
    }

    public virtual void OnRunAnimation(Vector3 vec)
    {
        _ani.SetBool(_HashRun, vec.x != 0 || vec.y != 0 ? true : false);
    }

    public virtual void OnTriggerAttackAnimation()
    {
        _ani.SetTrigger(_HashAttack);
    }
    public virtual void OnTriggerDeadAnimation()
    {
        _ani.SetTrigger(_HashDead);
    }
}
