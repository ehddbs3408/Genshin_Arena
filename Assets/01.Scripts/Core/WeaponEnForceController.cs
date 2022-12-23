using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponEnForceController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _waeponEnforceList;

    private TextMeshProUGUI _weaponAmountText;
    private TextMeshProUGUI _enforceAmountText;
    private TextMeshProUGUI _enforceItemAmountText;
    private TextMeshProUGUI _weaponDamageText;
    private Button _equipBtn;
    private Button _enforceBtn;

    private int _weaponAmount;
    private int _enforceAmount;
    private int _enforceItemAmount;
    private int _enforceNeedItemAmount;
    private int _weaponDamage;

    private GameObject _currentEnforcePanel;

    private Jaereonitem itemlist;
    private WeaponStatData weaponStatList;
    private WeaponJsonData drawingdata;
    PlayerJsonData user;

    private Jeareon _currentJeareonData;
    private WeaponStat _currentWeaponStat;

    private void Awake()
    {
        
        Init();
    }

    public void Init()
    {
        user = DataManager.LoadJsonFile<PlayerJsonData>(Application.dataPath + "/SAVE/Player", "User");
        itemlist = DataManager.LoadJsonFile<Jaereonitem>(Application.dataPath + "/SAVE/Weapon", "Jaereonitem");
        weaponStatList = DataManager.LoadJsonFile<WeaponStatData>(Application.dataPath + "/SAVE/Weapon", "WeaponStat");
        drawingdata = DataManager.LoadJsonFile<WeaponJsonData>(Application.dataPath + "/SAVE/Weapon", "WeaponList");





    }

    public void VoidEnforcePanel(int idx)
    {
        _currentEnforcePanel = _waeponEnforceList[idx];

        _weaponAmountText = _currentEnforcePanel.transform.Find("Amount").GetComponent<TextMeshProUGUI>();
        _enforceAmountText = _currentEnforcePanel.transform.Find("Amount of 재련").GetComponent<TextMeshProUGUI>();
        _enforceItemAmountText = _currentEnforcePanel.transform.Find("재련 아이템/Text (TMP)").GetComponent<TextMeshProUGUI>();
        _weaponDamageText = _currentEnforcePanel.transform.Find("Damage").GetComponent<TextMeshProUGUI>();
        _equipBtn = _currentEnforcePanel.transform.Find("장착").GetComponent<Button>();
        _enforceBtn = _currentEnforcePanel.transform.Find("재련").GetComponent<Button>();

        _equipBtn.onClick.RemoveAllListeners();
        _enforceBtn.onClick.RemoveAllListeners();

        _equipBtn.onClick.AddListener(EquipWeapon);
        _enforceBtn.onClick.AddListener(EnforceWeapon);

        _currentWeaponStat = GetWeaponData(idx);
        _weaponAmount = _currentWeaponStat.weaponCt.count;
        _enforceAmount = _currentWeaponStat.level;
        _enforceNeedItemAmount = _currentWeaponStat.reforgecount;
        _weaponDamage = _currentWeaponStat.Damage;

        _currentJeareonData = GetJeareonData(idx);
        _enforceItemAmount = _currentJeareonData.cnt;

        SetText();

        user = DataManager.LoadJsonFile<PlayerJsonData>(Application.dataPath + "/SAVE/Player", "User");
        
        _equipBtn.gameObject.SetActive(!(user.weaponStat.id == _currentWeaponStat.id));
    }

    private void SetText()
    {
        if (_enforceAmount >= 5)
        {
            _enforceItemAmountText.gameObject.SetActive(false);
            _enforceBtn.gameObject.SetActive(false);
        }

        _weaponAmountText.text = string.Format("개수 : {0}", _weaponAmount.ToString());
        _enforceAmountText.text = string.Format("재련 : {0}", _enforceAmount.ToString());
        _enforceItemAmountText.text = string.Format("( {0} / {1} )", _enforceItemAmount.ToString(), _enforceNeedItemAmount.ToString());
        _weaponDamageText.text = string.Format("공격력 : {0}", _weaponDamage);
    }

    private Jeareon GetJeareonData(int starIdx)
    {
        starIdx = starIdx >= 5 ? starIdx - 5 : starIdx;
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
    private void SaveJeareonData()
    {
        string json = DataManager.ObjectToJson(itemlist);
        DataManager.SaveJsonFile(Application.dataPath + "/SAVE/Weapon", "Jaereonitem", json);
    }
    private WeaponStat GetWeaponData(int idx)
    {
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
            data.reforgecount = 3;
            data.Damage = 100;
            data.weaponCt = null;
        }
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
            if(idx == 0 || idx == 5)
                data.weaponCt.count = 1;
            else
                data.weaponCt.count = 0;
        }

        return data;
    }
    private void SaveWeaponStatData()
    {
        string json = DataManager.ObjectToJson(weaponStatList);
        DataManager.SaveJsonFile(Application.dataPath + "/SAVE/Weapon", "WeaponStat", json);
    }
    private void SaveData()
    {
        _currentWeaponStat.Damage = _weaponDamage;
        _currentWeaponStat.level = _enforceAmount;
        _currentWeaponStat.reforgecount = _enforceNeedItemAmount;
        _currentWeaponStat.weaponCt.count = _weaponAmount;
        _currentJeareonData.cnt = _enforceItemAmount;

        bool isFound = false;
        for(int i = 0;i< weaponStatList.list.Count;i++)
        {
            if (weaponStatList.list[i].id == _currentWeaponStat.id)
            {
                isFound = true;
                weaponStatList.list[i] = _currentWeaponStat;
            }
        }
        if (!isFound)
            weaponStatList.list.Add(_currentWeaponStat);

        isFound = false;
        for (int i = 0; i < itemlist.list.Count; i++)
        {
            if (itemlist.list[i].reforgestarlevel == (_currentWeaponStat.id >= 5 ? _currentWeaponStat.id - 5 : _currentWeaponStat.id))
            {
                isFound = true;
                itemlist.list[i] = _currentJeareonData;
            }
        }
        if (!isFound)
            itemlist.list.Add(_currentJeareonData);

        SaveJeareonData();
        SaveWeaponStatData();

        WeaponCnt ct = _currentWeaponStat.weaponCt;
        WeaponJsonData data = DataManager.LoadJsonFile<WeaponJsonData>(Application.dataPath+"/SAVE/Weapon", "WeaponList");
        for (int i = 0; i < data.list.Count; i++)
        {
            if (data.list[i].name == ct.name)
            {
                data.list[i] = ct;
                string json = DataManager.ObjectToJson(data);
                DataManager.SaveJsonFile(Application.dataPath + "/SAVE/Weapon", "WeaponList", json);
                return;
            }
        }
    }

    private void EnforceWeapon()
    {
        if(_enforceNeedItemAmount >_enforceItemAmount)
        {
            DontEnforceEffect(_enforceItemAmountText.rectTransform, _enforceItemAmountText);
            return;
        }

        if (_currentWeaponStat.weaponCt.count <= 1)
        {

            DontEnforceEffect(_weaponAmountText.rectTransform, _weaponAmountText);
            return;
        }

        _weaponAmount--;
        _enforceItemAmount -= _enforceNeedItemAmount;
        _enforceAmount++;
        _weaponDamage += DamageEnforce(_currentWeaponStat.id);
        SetText();
        SaveData();
        if(user.weaponStat.id==_currentWeaponStat.id)
        {
            EquipWeapon();
        }
    }
 
    private void EquipWeapon()
    {
        if (_currentWeaponStat.weaponCt.count == 0)
        {

            DontEnforceEffect(_weaponAmountText.rectTransform, _weaponAmountText);
            return;
        }


        user.weaponStat = _currentWeaponStat;

        string json = DataManager.ObjectToJson(user);
        DataManager.SaveJsonFile(Application.dataPath + "/SAVE/Player", "User", json);

        _equipBtn.gameObject.SetActive(false);
    }

    private void DontEnforceEffect(RectTransform rect,TextMeshProUGUI text)
    {
        Debug.Log("Effect!!");
        DOTween.KillAll();
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            text.color = Color.red;
        });
        seq.Append(rect.DOShakeAnchorPos(0.2f,20,5,45));
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() =>
        {
            text.color = Color.white;
        });
    }

    private int DamageEnforce(int idx)
    {
        int damage = 0;
        switch (idx >= 5 ? idx - 5 : idx)
        {
            case 0:
                damage = 24;
                break;
            case 1:
                damage = 39;
                break;
            case 2:
                damage = 47;
                break;
            case 3:
                damage = 54;
                break;
            case 4:
                damage = 61;
                break;
        }
        return damage;
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
