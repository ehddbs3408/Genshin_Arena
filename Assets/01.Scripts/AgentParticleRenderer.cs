using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentParticleRenderer : MonoBehaviour
{
    private ParticleSystemRenderer _particleRenderer;

    private IEnumerator _activeCoroutine;

    private bool _isRightFaceDirection = false;
    private bool _isOnParticle = false;
    private void Awake()
    {
        _particleRenderer = GetComponent<ParticleSystemRenderer>();
        _particleRenderer.gameObject.SetActive(false);
        _activeCoroutine = ActiveOffCoroutine(0.4f);
    }

    public void Move(Vector2 vec)
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
    public void Move(Vector3 vec)
    {
        Debug.Log("ad");
        _particleRenderer.gameObject.SetActive(true);
        if (vec.x > 0)
        {
            _isRightFaceDirection = false;
        }
        else if (vec.x < 0)
        {
            _isRightFaceDirection = true;
        }
        _particleRenderer.flip = new Vector3(_isRightFaceDirection ? 1 : 0, 0, 0);

        //StopCoroutine(_activeCoroutine);
        StopAllCoroutines();
        StartCoroutine(ActiveOffCoroutine(0.5f));
    }

    private IEnumerator ActiveOffCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        _particleRenderer.gameObject.SetActive(false);
    }
}
