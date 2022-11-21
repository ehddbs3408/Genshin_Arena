using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    [SerializeField]
    UnityEvent<Vector3> OnMoveKeyInput;

    [SerializeField]
    UnityEvent OnAttackKeyInput;

    private void Update()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        OnMoveKeyInput?.Invoke(vec);

        if(Input.GetMouseButtonDown(0))
        {
            OnAttackKeyInput?.Invoke();
        }
    }
}
