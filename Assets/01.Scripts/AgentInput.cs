using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    [SerializeField]
    UnityEvent<Vector3> OnMoveInputKey;

    private void Update()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        OnMoveInputKey?.Invoke(vec);
    }
}
