using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class DamagePopupText : MonoBehaviour
{
    private TextMeshPro _text;
    private void Start()
    {
        Init();
        ;
    }
    private void OnEnable()
    {
        Init();
    }
    void Init()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1)).Join(transform.DOMoveY(5f, 1));
        seq.Append(_text.DOColor(new Color(0,0,0,0),0.2f));
        
        seq.AppendCallback(Die);
    }

    public void Die()
    {
        transform.DOKill();
        transform.gameObject.SetActive(false);
        Managers.Resource.Destroy(gameObject);
    }
}
