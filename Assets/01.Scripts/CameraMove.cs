using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform _target;

    [SerializeField]
    private float _myRotationX;
    private void Awake()
    {
        _target = GameObject.Find("Player").GetComponent<Transform>();
       
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetDir = _target.position - transform.position;
        float angle = Quaternion.FromToRotation(Vector3.forward, targetDir).eulerAngles.y;

        transform.rotation = Quaternion.Euler(_myRotationX, angle, 0);
    }
}
