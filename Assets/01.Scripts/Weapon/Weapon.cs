using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected WeaponDataSO _weaponData;

    private Transform _parentTrm;
    private bool _isEquip;

    private int weaponLevel;
    private float waeponExp;
    private int weaponStar;


    protected virtual void Awake()
    {
        _parentTrm = transform.parent;
    }

    private void Init()
    {
        //DataManager.LoadJsonFile()
    }
    public abstract void OnAttack(GameObject dealer);

    public void EquipWeapon(Transform parent)
    {
        if (_isEquip) return;

        _isEquip = true;
        _parentTrm = parent;
        transform.SetParent(_parentTrm);
    }

    public void DropWeapon()
    {
        if (_isEquip == false) return;

        _isEquip = false;
        _parentTrm = null;
        transform.SetParent(null);
    }
}
