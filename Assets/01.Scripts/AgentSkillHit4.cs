using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSkillHit4 : MonoBehaviour
{
    [SerializeField] private GameObject DamagePopupPrefab;

    private float activeDamage = 0;

    private float Damage = 0f;

    private float totalDamage = 0f;

    PlayerJsonData data;

    WaitForSeconds popupcooltime = new WaitForSeconds(0.05f);

    IHittable hit;


    private void Start()
    {
        hit = GetComponent<IHittable>();
        data = DataManager.LoadJsonFile<PlayerJsonData>(Application.dataPath + "/SAVE/Player", "User");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Skill"))
        {
            if (DamagePopupPrefab != null)
            {
                Skill();
            }
        }

        if(other.gameObject.CompareTag("SpecialSkill"))
        {
            if(DamagePopupPrefab != null)
            {
                if(data.weaponStat.id == 4)
                {
                    SkillDamage(1000f);
                    StartCoroutine(ThreeUP());
                    totalDamage = Damage * 3;

                }
                if(data.weaponStat.id == 9)
                {
                    SkillDamage(600f);
                    StartCoroutine(FiveUP());
                    totalDamage = Damage * 5;

                }
                
            }
        }
        Debug.Log("asd");
        hit.OnGethit((int)totalDamage, null);
    }
    
    void ShowDamagePopup()
    {
        GameObject go = Managers.Resource.Instantiate("DamagePopup",transform);
        go.GetComponent<TextMesh>().text = Damage.ToString();

    }

    void SkillDamage(float value)
    {
        activeDamage = data.weaponStat.Damage + (data.weaponStat.Damage * activeskillUI.SkillDamagePercent);
        Damage = activeDamage * value;

    }

    void Skill()
    {
        switch(data.weaponStat.id)
        {
            case 0:
                SkillDamage(120f);
                StartCoroutine(TwoUP());
                totalDamage = Damage * 2;
                break;
            case 1:
                SkillDamage(160f);
                StartCoroutine(ThreeUP());
                totalDamage = Damage * 3;
                break;
            case 2:
                SkillDamage(210f);
                StartCoroutine(ThreeUP());
                totalDamage = Damage * 3;
                break;
            case 3:
                SkillDamage(250f);
                StartCoroutine(FourUP());
                totalDamage = Damage * 4;
                break;
            case 4:
                SkillDamage(300f);
                StartCoroutine(FiveUP());
                totalDamage = Damage * 5;
                break;
            case 5:
                SkillDamage(70f);
                StartCoroutine(ThreeUP());
                totalDamage = Damage * 3;
                break;
            case 6:
                SkillDamage(110f);
                StartCoroutine(FourUP());
                totalDamage = Damage * 4;
                break;
            case 7:
                SkillDamage(160f);
                StartCoroutine(FourUP());
                totalDamage = Damage * 4;
                break;
            case 8:
                SkillDamage(160f);
                StartCoroutine(SixUP());
                totalDamage = Damage * 6;
                break;
            case 9:
                SkillDamage(210f);
                StartCoroutine(SevenUP());
                totalDamage = Damage * 7;
                break;

        }
    }

    IEnumerator TwoUP()
    {
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();

    }
    IEnumerator ThreeUP()
    {
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();

    }
    IEnumerator FourUP()
    {
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();

    }

    IEnumerator FiveUP()
    {
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();

    }

    IEnumerator SixUP()
    {
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();

    }

    IEnumerator SevenUP()
    {
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();
        yield return popupcooltime;
        ShowDamagePopup();

    }




}
