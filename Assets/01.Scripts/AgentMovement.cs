using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementSO _movenetData;
    private Rigidbody _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    public void Movement(Vector3 vec)
    {
        _rigid.velocity = vec * _movenetData.speed;
    }
}
