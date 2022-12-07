using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpriteRenderer : MonoBehaviour
{
    protected SpriteRenderer _spriteRenderer;


    protected bool _isRightFaceDirection = false;
    protected bool _isDeadFlag = false;
    protected bool _isDirectionFlag = true;

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public virtual void FaceDirection(float dir, float duration)
    {
        FaceDirection(duration);
        _spriteRenderer.flipX = dir > 0 ? false : true;
    }
    public void FaceDirection(Vector3 vec)
    {
        if (_isDeadFlag || _isDirectionFlag == false) return;
        if (vec.x > 0)
        {
            _isRightFaceDirection = false;
        }
        else if (vec.x < 0)
        {
            _isRightFaceDirection = true;
        }
        _spriteRenderer.flipX = _isRightFaceDirection;
    }

    #region Flags
    public void FaceDirectionFlagOff()
    {
        _isDirectionFlag = false;
    }
    public void FaceDirectionFlagOn()
    {
        _isDirectionFlag = true;
    }

    protected void FaceDirection(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(FaceDirectionCoroutine(duration));
    }

    private IEnumerator FaceDirectionCoroutine(float duration)
    {
        FaceDirectionFlagOff();
        yield return new WaitForSeconds(duration);
        FaceDirectionFlagOn();
    }

    public void SpriteRendererFlag(bool value = true)
    {
        _isDeadFlag = value;
    }

    #endregion
}
