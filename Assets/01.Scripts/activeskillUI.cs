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

    public static float SkillDamagePercent = 0;

    private float activetime = 8f;
    public static bool isactive = false;

    PlayerJsonData data;

    private void Start()
    {
        data = DataManager.LoadJsonFile<PlayerJsonData>(Application.dataPath + "/SAVE/Player", "User");
    }

    private void Update()
    {
        if (isactive == true)
        {
            activetime -= Time.deltaTime;
            if(data.weaponStat.id == 2 || data.weaponStat.id == 7)
            {
                SkillDamagePercent = 11f;
            }
            else if(data.weaponStat.id == 3 || data.weaponStat.id == 8)
            {
                SkillDamagePercent = 21f;
            }
            else if(data.weaponStat.id == 4|| data.weaponStat.id == 9)
            {
                SkillDamagePercent = 30f;
            }
            Cooltimestart(activetime);
        }
        if(activetime < 0)
        {
            SkillDamagePercent = 0f;
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
