using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataSO : ScriptableObject
{
    public int damage;
    public int attackDelay;
    public int attackAfterDelay;

    public float attackRadius;
    public float attackDiameter;

    public Sprite weaponSprite;
    public Animator weaponAnimator;

}
