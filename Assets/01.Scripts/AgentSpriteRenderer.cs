using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private ParticleSystemRenderer _particleRenderer;

    private bool _isRightFaceDirection = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleRenderer = GetComponent<ParticleSystemRenderer>();
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
        _particleRenderer.flip = new Vector3(_isRightFaceDirection ? 1 : 0, 0, 0);
        _spriteRenderer.flipX = _isRightFaceDirection;
    }
}
