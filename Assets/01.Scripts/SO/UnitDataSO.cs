using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Unit/Data")]
public class UnitDataSO : ScriptableObject
{
    #region Unit State
    public int maxHp;
    public int maxStamina;
    #endregion

    #region Attack State
    [Range(0,100)]
    public float stunResistance;
    [Range(0, 100)]
    public float knockBackResistance;
    #endregion
}
