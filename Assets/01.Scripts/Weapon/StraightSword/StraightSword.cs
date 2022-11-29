using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightSword : Weapon
{
    public override bool OnAttack(Vector3 clickPos, Vector3 enemyPos)
    {
        Vector2 dir = transform.position - clickPos;
        if (dir.sqrMagnitude < _weaponData.attackRadius)
        {
            float lookAngle = Vector3.Angle(transform.position, clickPos);

            //Vector3 rightDir = AngleToDir(lookAngle + _weaponData.attackAngle * 0.5f);
            //Vector3 leftDir = AngleToDir(lookAngle - _weaponData.attackAngle * 0.5f);
            Vector3 lookDir = AngleToDir(lookAngle);

            Vector3 enemyDir = (transform.position - enemyPos).normalized;
            float targetAngle = Mathf.Acos(Vector3.Dot(lookDir, enemyDir)) * Mathf.Rad2Deg;

            if (targetAngle <= _weaponData.attackAngle * 0.5)
                return true;
        }
        return false;
    }

    private Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
    }

    //private void OnDrawGizmos()
    //{
        
    //}
}


