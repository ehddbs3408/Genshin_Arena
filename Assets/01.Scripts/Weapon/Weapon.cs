using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponDataSO _weaponData;

    private Transform _parentTrm;
    private bool _isEquip;

    protected virtual void Awake()
    {
        _parentTrm = transform.parent;
    }
    protected abstract bool OnAttack(Vector3 pos);

    protected void EquipWeapon(Transform parent)
    {
        if (_isEquip) return;

        _isEquip = true;
        _parentTrm = parent;
        transform.SetParent(_parentTrm);
    }

    protected void DropWeapon()
    {
        if (_isEquip == false) return;

        _isEquip = false;
        _parentTrm = null;
        transform.SetParent(null);
    }
}
