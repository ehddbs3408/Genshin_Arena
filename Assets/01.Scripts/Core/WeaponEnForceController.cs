using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponEnForceController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _waeponEnforceList;

    private TextMeshProUGUI _weaponAmountText;
    private TextMeshProUGUI _enforceAmountText;
    private TextMeshProUGUI _enforceItemAmountText;
    private TextMeshProUGUI _weaponDamageText;

    private int _weaponAmount;
    private int _enforceAmount;
    private int _enforceItemAmount;
    private int _enforceNeedItemAmount;
    private int _weaponDamage;

    private GameObject _currentEnforcePanel;

    public void VoidEnforcePanel(int idx)
    {
        _currentEnforcePanel = _waeponEnforceList[idx];

        _weaponAmountText = _currentEnforcePanel.transform.Find("Amount").GetComponent<TextMeshProUGUI>();
        _enforceAmountText = _currentEnforcePanel.transform.Find("Amount of 재련").GetComponent<TextMeshProUGUI>();
        _enforceItemAmountText = _currentEnforcePanel.transform.Find("재련 아이템/Text (TMP)").GetComponent<TextMeshProUGUI>();
        _weaponDamageText = _currentEnforcePanel.transform.Find("Damage").GetComponent<TextMeshProUGUI>();

        WeaponStat ct = GetWeaponData(idx);
        _weaponAmount = ct.weaponCt.count;
        _enforceAmount = ct.level;
        _enforceItemAmount = ct.reforgecount;
        _weaponDamage = ct.Damage;

        Jeareon jeareon = GetJeareonData(idx);
        _enforceNeedItemAmount = jeareon.cnt;


        _weaponAmountText.text = string.Format("개수 : {0}", _weaponAmount.ToString());
        _enforceAmountText.text = string.Format("재련 : {0}", _enforceAmount.ToString());
        _enforceItemAmountText.text = string.Format("( {0} / {1} )", _enforceItemAmount.ToString(), _enforceNeedItemAmount.ToString());
        _weaponDamageText.text = string.Format("공격력 : {0}", _weaponDamage);
    }
    private Jeareon GetJeareonData(int starIdx)
    {
        starIdx = starIdx > 5 ? starIdx - 5 : starIdx;
        Jaereonitem itemlist = DataManager.LoadJsonFile<Jaereonitem>(Application.dataPath + "/SAVE/Weapon", "Jaereonitem");
        foreach(Jeareon item in itemlist.list)
        {
            if (item.reforgestarlevel == starIdx)
                return item;
        }

        Jeareon jeareon = new Jeareon();
        jeareon.reforgestarlevel = starIdx;
        jeareon.cnt = 0;

        return jeareon;
    }

    private WeaponStat GetWeaponData(int idx)
    {
        WeaponStatData weaponStatList = DataManager.LoadJsonFile<WeaponStatData>(Application.dataPath + "/SAVE/Weapon", "WeaponStat");
        WeaponStat data = null;

        foreach (WeaponStat stat in weaponStatList.list)
        {
            if (stat.id == idx)
                data = stat;
        }

        if(data == null)
        {
            data = new WeaponStat();
            data.id = idx;
            data.level = 0;
            data.reforgecount = 0;
            data.Damage = 100;
            data.weaponCt = null;
        }
        WeaponJsonData drawingdata = DataManager.LoadJsonFile<WeaponJsonData>(Application.dataPath + "/SAVE/Weapon", "WeaponList");
        string name = StarOfName(idx);
        foreach (WeaponCnt ct in drawingdata.list)
        {
            if (ct.name == name)
                data.weaponCt = ct;
        }
        if (data.weaponCt == null)
        {
            data.weaponCt = new WeaponCnt();
            data.weaponCt.name = name;
            data.weaponCt.count = 0;
        }

        return data;
    }

    private string StarOfName(int idx)
    {
        string name = "";
        switch (idx)
        {
            case 0:
                name = "만월검";
                break;
            case 1:
                name = "칠성검";
                break;
            case 2:
                name = "청운검";
                break;
            case 3:
                name = "월왕구천검";
                break;
            case 4:
                name = "찰나의 덧없는 삶";
                break;
            case 5:
                name = "반월창";
                break;
            case 6:
                name = "호마창";
                break;
            case 7:
                name = "용광창";
                break;
            case 8:
                name = "방천화극창";
                break;
            case 9:
                name = "흩날리는 부세의 풍경";
                break;
        }

        return name;
    }

}
