using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamagePopupText : MonoBehaviour
{

    private void Start()
    {
        Init();
    }
    private void OnEnable()
    {
        Init();
    }
    void Init()
    {
        DOTween.KillAll();
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1));
        seq.Join(transform.DOMoveY(5f, 1));
        seq.AppendCallback(Die);
    }

    public void Die()
    {
        Debug.Log("QWESDZCXCQWEDAVDS");
        gameObject.SetActive(false);
        Managers.Resource.Destroy(gameObject);
    }
}
