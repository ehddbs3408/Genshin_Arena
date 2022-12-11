using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIHeader : MonoBehaviour
{
    [field: SerializeField] public UnityEvent<Vector3> OnMovementKeyPress { get; set; }
    [field: SerializeField] public UnityEvent<Vector3> OnPointerPositionChanged { get; set; }

    [field: SerializeField] public UnityEvent OnFireButtonPress { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonRelease { get; set; }

    [SerializeField]
    protected AIState _currentState;

    public Transform target;
    public Transform basePosition = null;

    private AIActionData _aiActionData;
    public AIActionData AIAationData => _aiActionData;

    protected virtual void Awake()
    {
        _aiActionData = transform.Find("AI").GetComponent<AIActionData>();
    }
    private void Start()
    {
        target = GameManager.Instance.PlayerTrm;
    }

    public void SetAttackState(bool state)
    {
        _aiActionData.attack = state;
    }

    public void Attack()
    {
        OnFireButtonPress?.Invoke();
    }

    public void Move(Vector3 moveDirection, Vector3 targetPosition)
    {
        OnMovementKeyPress?.Invoke(moveDirection);
        OnPointerPositionChanged?.Invoke(targetPosition);
    }



    public void ChangeState(AIState state)
    {
        //�̰� ���� ���¸� �������ִ°Ŵ�.
        _currentState = state; //���� ����
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            OnMovementKeyPress?.Invoke(Vector2.zero);
        }
        else
        {
            _currentState.UdateState();
        }
    }
}
