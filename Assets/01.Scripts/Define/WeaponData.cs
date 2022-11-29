using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WeaponData
{
    public int weaponLevel;
    public float waeponExp;
    public int weaponStar;
}

[Serializable]
public class WeaponGroupData
{
    public List<WeaponData> weaponList;
}
