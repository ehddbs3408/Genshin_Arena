using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AnimatorState
{
    None,
    Walk,
    Attack,
    Dead
}
public class EnemyAnimation : AgentAnimation
{
    SkeletonAnimation monsterAnimator;

    private bool _isFace = false;

    private AnimatorState _currentState = AnimatorState.None;
    protected override void Awake()
    {
        base.Awake();
        monsterAnimator = transform.GetComponent<SkeletonAnimation>();
    }
    public override void OnRunAnimation(Vector3 vec)
    {
        if (vec == Vector3.zero) return;
        if (_currentState == AnimatorState.Walk) return;

        _currentState = AnimatorState.Walk;
        ChangeAnimation("Walk", true);
    }

    public override void OnTriggerAttackAnimation()
    {
        _currentState = AnimatorState.Attack;
        ChangeAnimation("Attack", false);
    }

    public override void OnTriggerDeadAnimation()
    {
        _currentState = AnimatorState.Dead;
        ChangeAnimation("Dead", false);
    }
    public void FaceDirection(Vector3 vec)
    {
        float dir = vec.x;
        if(dir > 0)
        {
            _isFace = true;
        }
        else
        {
            _isFace = false;
        }
        Vector3 size = transform.localScale;
        size.x = _isFace ? 0.5f : -0.5f;
        transform.localScale = size;

    }
    public void ChangeAnimation(string AnimationName,bool loop)  //Names are: Idle, Walk, Dead and Attack
    {
        if (monsterAnimator == null)
            return;

        bool IsLoop = loop;
        Debug.Log($"Changed Animation : {AnimationName} ");
        //set the animation state to the selected one
        monsterAnimator.AnimationState.SetAnimation(0, AnimationName, IsLoop);
    }
}
