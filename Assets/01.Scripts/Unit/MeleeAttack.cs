using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : UnitAttack
{
    SpriteRenderer _spriteRenderer;
    protected override void Awake()
    {
        base.Awake();

        _spriteRenderer = transform.Find("VisualSprite").GetComponent<SpriteRenderer>();
        _spriteRenderer.gameObject.SetActive(false);
    }
    protected override void OnAttack(IHittable hit)
    {
        if (_isAttackFlag == false) return;

        _spriteRenderer.gameObject.SetActive(true);
    }



}
