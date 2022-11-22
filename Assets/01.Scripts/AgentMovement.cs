using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementSO _movenetData;

    [SerializeField]
    private string rigidbodyPath;
    private Rigidbody _rigid;
    

    private bool _isStop = false;
    private bool _stopFlag = false;
    private void Awake()
    {
        _rigid = transform.Find(rigidbodyPath).GetComponent<Rigidbody>();
    }

    public void Movement(Vector3 vec)
    {
        if (_isStop || _stopFlag) return;
        _rigid.velocity = vec * _movenetData.speed;
    }

    public void StopMovement()
    {
        _rigid.velocity = Vector3.zero;
    }

    public void StopMovement(float duration)
    {
        _rigid.velocity = Vector3.zero;
        StartCoroutine(MovementStopDuration(duration));
    }
    public void MovementStopFlag(bool value = true)
    {
        _rigid.velocity = Vector3.zero;
        _stopFlag = value;
    }

    private IEnumerator MovementStopDuration(float duration)
    {
        _isStop = true;
        yield return new WaitForSeconds(duration);
        _rigid.velocity = Vector3.zero;
        _isStop = false;
    }
}
