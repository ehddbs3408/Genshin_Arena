using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawingController : MonoBehaviour
{
    [SerializeField]
    private Image _drawingPanel;
    [SerializeField]
    private Image _waeponImage;
    [SerializeField]
    private Transform _drawingEffect;

    [SerializeField]
    private List<Sprite> _spriteList;

    [SerializeField]
    private DrawingWeaponPossibility _data;
    
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

            _waeponImage.sprite = _spriteList[DrawingWeapon()];
            _waeponImage.enabled = true;
        });
    }

    public void SkipExit()
    {
        _drawingPanel.enabled = false;
        _drawingEffect.localScale = Vector3.zero;
        _waeponImage.enabled = false;
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
