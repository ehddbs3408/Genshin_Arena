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

    public void FaceDirectionFlagOff()
    {
        _isDirectionFlag = false;
    }
    public void FaceDirectionFlagOn()
    {
        _isDirectionFlag = true;
    }

    public void FaceDirection(Vector3 vec)
    {
        if (_isDeadFlag || _isDirectionFlag == false) return;

        if(vec.x > 0)
        {
            _isRightFaceDirection = false;
        }
        else if( vec.x < 0)
        {
            _isRightFaceDirection = true;
        }
        _spriteRenderer.flipX = _isRightFaceDirection;
    }

    public void SpriteRendererFlag(bool value = true)
    {
        _isDeadFlag = value;
    }
}
