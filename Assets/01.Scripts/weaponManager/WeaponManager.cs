using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WeaponManager : MonoBehaviour
{

    public void Click(int num)
    {
        WeaponSkill.weaponskillnum = num;
    }

    public void Gamestart()
    {
        SceneManager.LoadScene("SkillEffect");
    }

    public void Gacha()
    {
        WeaponJsonData weaponjsondata = new WeaponJsonData();
        WeaponCnt weaponcnt = new WeaponCnt();
        weaponcnt.name = "Âû³ªÀÇ µ¡¾ø´Â »î";
        weaponcnt.count = 1;
        weaponjsondata.list.Add(weaponcnt);
        
        //weaponcnt.name = ""
        
        string json = DataManager.ObjectToJson(weaponjsondata);

        DataManager.SaveJsonFile("SAVE/Weapon", "weapon", json);

        PlayerJsonData data = DataManager.LoadJsonFile<PlayerJsonData>("SAVE/Player", "User");

        WeaponJsonData wjdata = DataManager.LoadJsonFile<WeaponJsonData>("SAVE/Weapon", "weapon");
        foreach(WeaponCnt cn in wjdata.list)
        {
            if(cn.name == "Âû³ªÀÇ µ¡¾ø´Â »î")
            {

            }
        }

    }
}
