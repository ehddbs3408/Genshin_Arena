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

    private float Playerspeed;

    private bool _isStop = false;
    private bool _stopFlag = false;
    public static bool _isskillplaying = false;
    private void Awake()
    {
        _rigid = transform.Find(rigidbodyPath).GetComponent<Rigidbody>();
        Playerspeed = _movenetData.speed;
    }

    public void Movement(Vector3 vec)
    {
        if (_isStop || _stopFlag) return;
        _rigid.velocity = vec * _movenetData.speed;
    }

    public void Dash(Vector3 vec)
    {
        StopMovement(0.1f);
        _rigid.AddForce(vec.normalized * _movenetData.dashPower,ForceMode.Impulse);
    }
    public void Dash(Vector3 vec,float power)
    {
        StopMovement(0.1f);
        _rigid.AddForce(vec.normalized * power, ForceMode.Impulse);
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
        _rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(duration);
        _isStop = false;
    }
    
    public void Stop()
    {
        _movenetData.speed = 0f;
        _isskillplaying = true;

    }

    public void Play()
    {
        _movenetData.speed = Playerspeed;
        _isskillplaying = false;

    }
}
