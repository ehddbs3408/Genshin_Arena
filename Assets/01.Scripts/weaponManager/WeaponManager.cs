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

}
