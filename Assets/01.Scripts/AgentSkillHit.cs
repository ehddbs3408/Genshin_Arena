using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSkillHit : MonoBehaviour
{
    [SerializeField] private GameObject DamagePopupPrefab;

    public static float addDamage;

    private float Damage;

    PlayerJsonData data;



    private void Start()
    {
        data = DataManager.LoadJsonFile<PlayerJsonData>(Application.dataPath + "/SAVE/Player", "User");
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Skill"))
        {
            if (DamagePopupPrefab != null)
            {
                Skill();
                ShowDamagePopup();
            }
        }
    }
    
    void ShowDamagePopup()
    {
        GameObject go = Managers.Resource.Instantiate("DamagePopup",transform);
        go.GetComponent<TextMesh>().text = Damage.ToString();
    }

    void SkillDamage(float value)
    {
        
        Damage = data.weaponStat.Damage * value;
    }

    void Skill()
    {
        switch(data.weaponStat.id)
        {
            case 0:
                SkillDamage(120f);
                break;
            case 1:
                SkillDamage(160f);
                break;
            case 2:
                SkillDamage(210f);
                break;
            case 3:
                SkillDamage(250f);
                break;
            case 4:
                SkillDamage(300f);
                break;
            case 5:
                SkillDamage(70f);
                break;
            case 6:
                SkillDamage(110f);
                break;
            case 7:
                SkillDamage(160f);
                break;
            case 8:
                SkillDamage(160f);
                break;
            case 9:
                SkillDamage(210f);
                break;



        }
    }
}
