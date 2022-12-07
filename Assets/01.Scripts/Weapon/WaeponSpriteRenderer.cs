using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaeponSpriteRenderer : AgentSpriteRenderer
{
    private GameObject _body;

    protected override void Awake()
    {
        base.Awake();
        _body = transform.parent.gameObject;
    }

    public void WaeponDirection(Vector3 vec)
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
        _body.transform.localScale = new Vector3(_isRightFaceDirection ? -1 : 1, 1, 1);
    }
    public override void FaceDirection(float dir, float duration)
    {
        FaceDirection(duration);
        _body.transform.localScale = new Vector3(dir > 0 ? 1 : -1, 1, 1);
    }
}
