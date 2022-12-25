using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscSkillExplain : MonoBehaviour
{
    [SerializeField] GameObject[] list;
    [SerializeField] GameObject setting;
    [SerializeField] GameObject volumeSetting;
    [SerializeField] GameObject EquipItemPanel;
    [SerializeField] GameObject CharacterInfo;
    [SerializeField] GameObject DrawingWeaponPanel;
    [SerializeField] GameObject RealGameOutPanel;

    bool explainPanelactive = false;

    int isclick = 0;

    public void Click()
    {
        
        isclick = 1;
    }
    public void Click1()
    {
        isclick = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (setting.activeSelf == true && volumeSetting.activeSelf == false && RealGameOutPanel.activeSelf == false)
            {
                setting.SetActive(false);
            }
            else if (setting.activeSelf == false && EquipItemPanel.activeSelf == false && CharacterInfo.activeSelf == false && DrawingWeaponPanel.activeSelf == false)
            {
                setting.SetActive(true);
            }
            else if(volumeSetting.activeSelf == true)
            {
                volumeSetting.SetActive(false);
            }
            else
            { 
                RealGameOutPanel.SetActive(false);
            }

            if (setting.activeSelf == false && EquipItemPanel.activeSelf == true)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].SetActive(false);
                }
                isclick++;
            }

            if (isclick == 2)
            {
                EquipItemPanel.gameObject.SetActive(false);
                isclick = 0;
            }
        }
    }

    

}
