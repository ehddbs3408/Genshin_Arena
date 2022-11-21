using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    

    private bool _isRightFaceDirection = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    public void FaceDirection(Vector3 vec)
    {
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
}
