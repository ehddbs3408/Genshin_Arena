using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataSO : ScriptableObject
{
    public int damage;
    public int attackDelay;
    public int attackAfterDelay;


    public float attackRadius;
    [Range(0,360)]
    public float attackAngle;

    public Sprite weaponSprite;
    public Animator weaponAnimator;
}
