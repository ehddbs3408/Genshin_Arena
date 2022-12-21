using System.Collections.Generic;
using System;

[Serializable]
public class WeaponStat
{
    public int weaponnum;
    public int reforgecount;
    public int Damage;
}

public class WeaponStatData
{
    public List<WeaponStat> list;
}
