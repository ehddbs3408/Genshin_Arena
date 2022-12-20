using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    private Transform _staminaBar;

    private void Awake()
    {
        _staminaBar = transform.Find("Bar").GetComponent<Transform>();
    }

    public void ChangeStaminaBar(float value)
    {
        Vector3 size = _staminaBar.transform.localScale;
        size.y = value;
        _staminaBar.localScale = size;
    }
}
