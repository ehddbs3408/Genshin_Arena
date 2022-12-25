using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1)).Join(transform.DOMoveY(3f, 1));
        seq.Append(transform.DOScale(new Vector3(0f, 0f, 0f), 0.1f));
        
        seq.AppendCallback(Die);

        //seq.Insert(2f,transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1));
        //seq.Insert(2f,);
        //seq.Insert(0f, transform.DOScale(new Vector3(0f,0f,0f), 0.5f));
        //seq.AppendCallback(Die);
    }

    public void Die()
    {
        transform.DOKill();
        transform.gameObject.SetActive(false);
        Managers.Resource.Destroy(gameObject);
    }
}
