using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentParticleRenderer : MonoBehaviour
{
    private ParticleSystemRenderer _particleRenderer;

    private bool _isRightFaceDirection = false;
    private void Awake()
    {
        _particleRenderer = GetComponent<ParticleSystemRenderer>();
    }

    public void Move(Vector3 vec)
    {
        if (vec.x > 0)
        {
            _isRightFaceDirection = false;
        }
        else if (vec.x < 0)
        {
            _isRightFaceDirection = true;
        }
        _particleRenderer.gameObject.SetActive(vec.x != 0 || vec.y != 0 ? true : false);
        _particleRenderer.flip = new Vector3(_isRightFaceDirection ? 1 : 0, 0, 0);
    }
}
