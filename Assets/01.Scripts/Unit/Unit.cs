using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IHittable, IKnockBack, IStun
{
    [SerializeField]
    protected UnitDataSO unitData;

    #region Hittable
    public int Health { get; set; }

    public abstract void OnDead();

    public virtual void OnGethit(int damaged, GameObject dealer)
    {
        Health -= damaged;

        if(Health <  0)
        {
            OnDead();
        }
    }
    #endregion

    public abstract void OnGetKnockBack(Vector3 dir, float power, float duration, GameObject dealer = null);

    public abstract void OnGetStun(float power, float duration);
}
