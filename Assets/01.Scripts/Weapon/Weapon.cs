using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected WeaponDataSO _weaponData;

    protected AgentAnimation _agentAnimation;
    protected AgentSpriteRenderer _agentSpriteRenderer;

    private Transform _parentTrm;
    private bool _isEquip;

    private int weaponLevel;
    private float waeponExp;
    private int weaponStar;


    protected virtual void Awake()
    {
        _parentTrm = transform.parent;
        _agentAnimation = transform.Find("VisualSprite").GetComponent<AgentAnimation>();
        _agentSpriteRenderer = transform.Find("VisualSprite").GetComponent<AgentSpriteRenderer>();
    }

    private void Init()
    {
        //DataManager.LoadJsonFile()
    }
    public abstract void OnAttack(GameObject dealer);

    public void WeaponVisualFilp(float dir)
    {
        _agentSpriteRenderer.FaceDirection(new Vector3(dir, 0, 0));

    }

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
