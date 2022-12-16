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

    [SerializeField]
    UnityEvent<Vector3> OnDashkeyInput;

    private void Update()
    {
        MoveInput();
        AttackInput();
    }
    private void AttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttackKeyInput?.Invoke();
        }
    }

    private void MoveInput()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        OnMoveKeyInput?.Invoke(vec);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnDashkeyInput?.Invoke(vec);
        }
    }
}
