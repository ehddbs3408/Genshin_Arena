using System.Collections.Generic;
using System;

[Serializable]
public class WeaponStat
{
    public int id;
    public int level;
    public WeaponCnt weaponCt;
    public int reforgecount;
    public int Damage;
}

public class WeaponStatData
{
    public List<WeaponStat> list;
}
