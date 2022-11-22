using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Unit/AttackData")]
public class UnitAttackDataSO : ScriptableObject
{
    public int damage;
    public float attackDelay;

    [Range(0,100)]
    public int power;
    public float stunTime;
    
}
