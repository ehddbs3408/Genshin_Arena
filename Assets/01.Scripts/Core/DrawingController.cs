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
    private Image _skipBtn;
    [SerializeField]
    private Image _drawingBtn;
    [SerializeField]
    private TextMeshProUGUI _drawingtext;

    [SerializeField]
    private List<Sprite> _spriteList;
    [SerializeField]
    private List<Image> _starList;

    [SerializeField]
    private DrawingWeaponPossibility _data;

    private int drawing;

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
        _skipBtn.gameObject.SetActive(false);
        drawing = PlayerPrefs.GetInt("Drawing");
        _drawingtext.text = drawing.ToString();
        for (int i = 0; i < 5; i++)
        {
            _starList[i].gameObject.SetActive(false);
        }
    }
    public void DrawingMotion()
    {
        
        if (drawing < 1)
        {
            DontEffect();
            return;   
        }

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
            int idx = DrawingWeaponPossibility();
            _waeponImage.enabled = true;
            _waeponNamePanel.SetActive(true);

            //_weaponNameText.text = idx.ToString();
            DrawingWeapon(idx);

            StartCoroutine(StarMotion(idx));
            drawing--;
            PlayerPrefs.SetInt("Drawing", drawing);
        });
    }
    public void DrawingMAxMotion()
    {

        if (drawing < 1)
        {
            DontEffect();
            return;
        }

        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() => {
            _drawingPanel.enabled = true;
            _drawingEffect.localScale = Vector3.zero;
        });
        seq.Append(_drawingEffect.DOScale(6, 1.5f));
        seq.Join(_drawingEffect.DOShakeRotation(1.5f, 360, 0));
        seq.Append(_drawingPanel.DOColor(Color.white, 0.5f));
        seq.AppendCallback(() =>
        {
            int idx = DrawingWeaponPossibility();
            _waeponImage.enabled = true;
            _waeponNamePanel.SetActive(true);

            //_weaponNameText.text = idx.ToString();
            DrawingWeapon(4);

            StartCoroutine(StarMotion(4));
            drawing--;
            PlayerPrefs.SetInt("Drawing", drawing);
        });
    }
    private void DontEffect()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_drawingtext.rectTransform.DOShakeAnchorPos(0.3f, 20));
        seq.Join(_drawingtext.DOColor(Color.red, 0.3f));
        seq.Append(_drawingtext.DOColor(Color.black, 0.3f));

    }
    private IEnumerator StarMotion(int count)
    {
        for(int i = 0;i<count+1;i++)
        {
            _starList[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
        _skipBtn.gameObject.SetActive(true);
    }

    public void SkipExit()
    {
        Init();
    }
    private void DrawingWeapon(int idx)
    {
        idx = Random.Range(0, 2) == 0 ? idx : idx + 5;

        string waeponName = StarOfName(idx);

        _waeponImage.sprite = _spriteList[idx];
        _weaponNameText.text = waeponName;



        WeaponJsonData weapon = DataManager.LoadJsonFile<WeaponJsonData>(Application.dataPath + "/SAVE/Weapon", "WeaponList");
        if(weapon == null)
        {
            WeaponCnt data = new WeaponCnt();

            data.name = waeponName;
            data.count = 1;

            weapon.list.Add(data);
        }
        else
        {
            bool find = false;
            for(int i = 0;i<weapon.list.Count;i++)
            {
                if (weapon.list[i].name == waeponName)
                {
                    weapon.list[i].count++;
                    find = true;
                    break;
                }          
            }

            if(!find)
            {
                WeaponCnt data = new WeaponCnt();

                data.name = waeponName;
                data.count = 1;

                weapon.list.Add(data);
            }
        }

        string json = DataManager.ObjectToJson(weapon);
        DataManager.SaveJsonFile(Application.dataPath + "/SAVE/Weapon", "WeaponList",json);
    }

    private string StarOfName(int idx)
    {
        string name = "";
        switch (idx)
        {
            case 0:
                name = "¸¸¿ù°Ë";
                break;
            case 1:
                name = "Ä¥¼º°Ë";
                break;
            case 2:
                name = "Ã»¿î°Ë";
                break;
            case 3:
                name = "¿ù¿Õ±¸Ãµ°Ë";
                break;
            case 4:
                name = "Âû³ªÀÇ µ¡¾ø´Â »î";
                break;
            case 5:
                name = "¹Ý¿ùÃ¢";
                break;
            case 6:
                name = "È£¸¶Ã¢";
                break;
            case 7:
                name = "¿ë±¤Ã¢";
                break;
            case 8:
                name = "¹æÃµÈ­±ØÃ¢";
                break;
            case 9:
                name = "Èð³¯¸®´Â ºÎ¼¼ÀÇ Ç³°æ";
                break;
        }

        return name;
    }

    private int DrawingWeaponPossibility()
    {
        float chance = PossibilityToValue() * 0.1f;
        Debug.Log(chance);
        int result = 0;
        if (_data.fiveStartPossibility >= chance)
            result = 4;
        else if (_data.fourStartPossibility >= chance)
            result = 3;
        else if (_data.threeStartPossibility >= chance)
            result = 2;
        else if (_data.twoStartPossibility >= chance)
            result = 1;

        return result;
    }

    private float PossibilityToValue()
    {
        int chance = Random.Range(0, 1000);
        return chance;
    }
}
