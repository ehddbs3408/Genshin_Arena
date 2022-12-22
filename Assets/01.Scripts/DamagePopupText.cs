using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamagePopupText : MonoBehaviour
{

    Sequence seq;
    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        Init();
    }
    private void OnEnable()
    {
        Init();
    }
    void Init()
    {
         
        seq.Append(transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1));
        seq.Join(transform.DOMoveY(5f, 1));
        seq.AppendCallback(Die);
    }

    public void Die()
    {
        seq.Kill();
        Debug.Log("QWESDZCXCQWEDAVDS");
        gameObject.SetActive(false);
        Managers.Resource.Destroy(gameObject);
    }
}
