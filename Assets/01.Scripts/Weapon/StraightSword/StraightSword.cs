using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightSword : Weapon
{
    LayerMask mask;
    public override void OnAttack(GameObject dealer)
    {
        mask = LayerMask.GetMask("Unit");
        Collider[] cols = Physics.OverlapSphere(transform.position, _weaponData.attackRadius, mask);

        Vector3 vec = Vector3.zero;
        Ray ray = GameManager.Instance.MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitRay;
        if(Physics.Raycast(ray,out hitRay))
        {
            vec = hitRay.point;
        }
        else
        {
            return;
        }

        foreach (Collider col in cols)
        {
            if (AttackCheck(vec, col.gameObject.transform.position))
            {
                IHittable hit = col.gameObject.GetComponent<IHittable>();
                hit?.OnGethit(10, gameObject);
            }
        }
    }

    protected bool AttackCheck(Vector3 clickPos, Vector3 enemyPos)
    {
        clickPos = new Vector3(clickPos.x, 0, clickPos.z);
        enemyPos = new Vector3(enemyPos.x, 0, enemyPos.z);
        Vector2 dir = transform.position - clickPos;
        float lookAngle = GetAngle(transform.position, clickPos);
        if (dir.sqrMagnitude < _weaponData.attackRadius)
        {

            
            Debug.Log(lookAngle);

            Vector3 rightDir = AngleToDir(lookAngle + _weaponData.attackAngle * 0.5f);
            Vector3 leftDir = AngleToDir(lookAngle - _weaponData.attackAngle * 0.5f);
            Vector3 lookDir = AngleToDir(lookAngle);
       
            Debug.DrawRay(transform.position, rightDir * _weaponData.attackRadius, Color.blue);
            Debug.DrawRay(transform.position, leftDir * _weaponData.attackRadius, Color.blue);
            Debug.DrawRay(transform.position, lookDir * _weaponData.attackRadius, Color.cyan);

            Vector3 enemyDir = (transform.position - enemyPos).normalized;
            float targetAngle = Mathf.Acos(Vector3.Dot(lookDir, enemyDir)) * Mathf.Rad2Deg;

            if (targetAngle <= _weaponData.attackAngle * 0.5)
                return true;
        }
        return false;
    }
    private float GetAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }
    private Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
    }

}


