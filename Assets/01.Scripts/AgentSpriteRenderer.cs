using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;


    private bool _isRightFaceDirection = false;
    private bool _isDeadFlag = false;
    private bool _isDirectionFlag = true;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }


    public void FaceDirection(float dir, float duration)
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

    private void FaceDirection(float duration)
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
