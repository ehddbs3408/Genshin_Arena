using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockBack
{
    void OnGetKnockBack(Vector3 dir, float power,float duration,GameObject dealer = null);
}
