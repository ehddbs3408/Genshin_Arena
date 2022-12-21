using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class activeskillUI : MonoBehaviour
{
    [SerializeField] TMP_Text cooltime;
    [SerializeField] Image image;

    public static Action func;

    
    private float activetime = 8f;
    public static bool isactive = false;

    public void Update()
    {
        if (isactive == true)
        {
            activetime -= Time.deltaTime;

            Cooltimestart(activetime);
        }
        if(activetime < 0)
        {
            gameObject.SetActive(false);
            isactive = false;
            activetime = 8;
        }
    }

    public void Cooltimestart(float _val)
    {
        float fillamount = 1.0f - (_val / 8f);
        image.fillAmount = fillamount;
        cooltime.text = _val.ToString("0.0");
        
    }

}
