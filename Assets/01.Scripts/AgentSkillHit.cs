using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSkillHit : MonoBehaviour
{
    [SerializeField] private GameObject DamagePopupPrefab;

    private float activeDamage = 0;

    private float Damage = 0;

    PlayerJsonData data;

    WaitForSeconds popupcooltime = new WaitForSeconds(0.05f);


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
                break;
            case 1:
                SkillDamage(160f);
                StartCoroutine(ThreeUP());
                break;
            case 2:
                SkillDamage(210f);
                StartCoroutine(ThreeUP());
                break;
            case 3:
                SkillDamage(250f);
                StartCoroutine(FourUP());
                break;
            case 4:
                SkillDamage(300f);
                StartCoroutine(FiveUP());
                break;
            case 5:
                SkillDamage(70f);
                StartCoroutine(ThreeUP());
                break;
            case 6:
                SkillDamage(110f);
                StartCoroutine(FourUP());
                break;
            case 7:
                SkillDamage(160f);
                StartCoroutine(FourUP());
                break;
            case 8:
                SkillDamage(160f);
                StartCoroutine(SixUP());
                break;
            case 9:
                SkillDamage(210f);
                StartCoroutine(SevenUP());
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
