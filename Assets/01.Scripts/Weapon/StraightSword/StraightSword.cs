using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightSword : Weapon
{
    Vector3 rightDir;
    Vector3 leftDir;
    Vector3 lookDir;

    LayerMask mask;
    public override void OnAttack(GameObject dealer)
    {
        mask = LayerMask.GetMask("Unit");
        Collider[] cols = Physics.OverlapSphere(transform.position, _weaponData.attackRadius, mask);

        Vector3 vec = Vector3.zero;
        Ray ray = GameManager.Instance.MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitRay;

        Player player = dealer.GetComponent<Player>();

        //Debug.DrawRay(GameManager.Instance.MainCam.transform.position, ray.direction,Color.red);
        if(Physics.Raycast(ray,out hitRay,LayerMask.GetMask("Ground")))
        {
            float dirX =  hitRay.point.x - dealer.transform.position.x;
            _agentSpriteRenderer.FaceDirection(dirX,_weaponData.attackDelay);
            player.AgentSprite.FaceDirection(dirX, _weaponData.attackDelay);
            vec = hitRay.point;
        }
        else
        {
            float dirX = hitRay.point.x - dealer.transform.position.x;
            _agentSpriteRenderer.FaceDirection(dirX, _weaponData.attackDelay);
            player.AgentSprite.FaceDirection(dirX, _weaponData.attackDelay);
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
        Vector3 dir =  clickPos - transform.position;
        float lookAngle = GetAngle(transform.position, clickPos);

        if (dir.magnitude < _weaponData.attackRadius)
        {
            //Vector3 rightDir = AngleToDir(lookAngle + _weaponData.attackAngle * 0.5f);
            //Vector3 leftDir = AngleToDir(lookAngle - _weaponData.attackAngle * 0.5f);
            //Vector3 lookDir = AngleToDir(lookAngle);
            rightDir = AngleToDir(lookAngle + _weaponData.attackAngle * 0.5f);
            leftDir = AngleToDir(lookAngle - _weaponData.attackAngle * 0.5f);
            lookDir = AngleToDir(lookAngle);

            Vector3 enemyDir = (enemyPos - transform.position).normalized;
            float targetAngle = Mathf.Acos(Vector3.Dot(dir.normalized, enemyDir)) * Mathf.Rad2Deg;

            if (targetAngle <= _weaponData.attackAngle * 0.5)
                return true;
        }
        return false;
    }
    private float GetAngle(Vector3 from, Vector3 to)
    {
        float angle = Quaternion.FromToRotation(Vector3.forward, to - from).eulerAngles.y;
        if (angle > 180)
        {
            angle = angle - 360;
        }
        return angle;
    }
    private Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, rightDir * _weaponData.attackRadius, Color.blue);
        Debug.DrawRay(transform.position, leftDir * _weaponData.attackRadius, Color.blue);
        Debug.DrawRay(transform.position, lookDir * _weaponData.attackRadius, Color.cyan);
    }
}


