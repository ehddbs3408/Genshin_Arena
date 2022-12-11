using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancDesision : AIDecision
{
    [Range(0.1f, 30f)]
    public float distance = 5f;
    public override bool MakeADecision()
    {
        float calc = 0f;

        calc = Vector2.Distance(_enemyBrain.target.position, transform.position);

        if (calc < distance)
        {
            if (_aiActionData.targetSpotted == false)
            {
                _aiActionData.targetSpotted = true;
            }
        }
        else
        {
            _aiActionData.targetSpotted = false;
        }

        return _aiActionData.targetSpotted;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeGameObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, distance);
            Gizmos.color = Color.white;
        }
    }

#endif
}
