using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawingController : MonoBehaviour
{
    [SerializeField]
    private Image _drawingPanel;
    [SerializeField]
    private Image _waeponImage;
    [SerializeField]
    private Transform _drawingEffect;
    [SerializeField]
    private GameObject _waeponNamePanel;
    [SerializeField]
    private TextMeshProUGUI  _weaponNameText; 

    [SerializeField]
    private List<Sprite> _spriteList;
    [SerializeField]
    private List<Image> _starList;

    [SerializeField]
    private DrawingWeaponPossibility _data;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _waeponNamePanel.SetActive(false);
        _drawingPanel.color = Color.black;
        _drawingPanel.enabled = false;
        _drawingEffect.localScale = Vector3.zero;
        _waeponImage.enabled = false;
        for (int i = 0; i < 5; i++)
        {
            _starList[i].gameObject.SetActive(false);
        }
    }
    public void DrawingMotion()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>{
            _drawingPanel.enabled = true;
            _drawingEffect.localScale = Vector3.zero;
        });
        seq.Append(_drawingEffect.DOScale(6, 1.5f));
        seq.Join(_drawingEffect.DOShakeRotation(1.5f,360,0));
        seq.Append(_drawingPanel.DOColor(Color.white, 0.5f));
        seq.AppendCallback(() =>
        {
            int a = DrawingWeapon();
            _waeponImage.enabled = true;
            _waeponNamePanel.SetActive(true);
            _weaponNameText.text = a.ToString();

            StartCoroutine(StarMotion(a));

            a = Random.Range(0, 2) == 0 ? a : a + 5;
            _waeponImage.sprite = _spriteList[a];
            
        });
        seq.AppendCallback(() =>
        {

        });
    }

    private IEnumerator StarMotion(int count)
    {
        for(int i = 0;i<count+1;i++)
        {
            _starList[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void SkipExit()
    {
        Init();
    }

    private int DrawingWeapon()
    {
        float chance = PossibilityToValue() * 0.1f;
        
        int result = 0;
        if (_data.fiveStartPossibility > chance)
            result = 4;
        else if (_data.fourStartPossibility > chance)
            result = 3;
        else if (_data.threeStartPossibility > chance)
            result = 2;
        else if (_data.twoStartPossibility > chance)
            result = 1;

        return result;
    }

    private float PossibilityToValue()
    {
        float chance = Random.Range(0, 1000);
        Debug.Log(chance);
        return chance;
    }
}
