using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Player/Movement")]
public class PlayerMovementSO : ScriptableObject
{
    [Range(0,10)]
    public float speed;

    public float dashPower;
}
