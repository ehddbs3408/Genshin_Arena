using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Playables;

public class WeaponSkill : MonoBehaviour
{
    #region ¿Ã∆Â∆ÆµÈ
    [SerializeField] VisualEffect onestarswordskill;

    [SerializeField] VisualEffect onestarspearskill;

    [SerializeField] VisualEffect twostarswordskillfirst;
    [SerializeField] VisualEffect twostarswordskillsecond;
    [SerializeField] VisualEffect twostarswordskillthird;

    [SerializeField] VisualEffect twostarspearskillfirst;
    [SerializeField] VisualEffect twostarspearskillsecond;

    [SerializeField] VisualEffect threestarswordskillfirst;
    [SerializeField] VisualEffect threestarswordskillsecond;
    [SerializeField] VisualEffect threestarswordskillthree;
    [SerializeField] VisualEffect threestarswordskillfour;

    [SerializeField] VisualEffect threestarspearskillfirst;
    [SerializeField] VisualEffect threestarspearskillsecond;
    [SerializeField] VisualEffect threestarspearskillthree;

    [SerializeField] VisualEffect fourstarswordskillfirst;
    [SerializeField] VisualEffect fourstarswordskillsecond;
    [SerializeField] VisualEffect fourstarswordskillthree;
    [SerializeField] VisualEffect fourstarswordskillfour;
    [SerializeField] VisualEffect fourstarswordskillfive;
    [SerializeField] VisualEffect fourstarswordskillsix;
    [SerializeField] VisualEffect fourstarswordskillseven;

    [SerializeField] VisualEffect fourstarspearskillfirst;
    [SerializeField] VisualEffect fourstarspearskillsecond;
    [SerializeField] VisualEffect fourstarspearskillthree;
    [SerializeField] VisualEffect fourstarspearskillfour;
    [SerializeField] VisualEffect fourstarspearskillfive;
    [SerializeField] VisualEffect fourstarspearskillsix;

    [SerializeField] VisualEffect fivestarswordskillfirst;
    [SerializeField] VisualEffect fivestarswordskillsecond;
    [SerializeField] VisualEffect fivestarswordskillthree;
    [SerializeField] VisualEffect fivestarswordskillfour;
    [SerializeField] VisualEffect fivestarswordskillfive;
    [SerializeField] VisualEffect fivestarswordskillsix;
    [SerializeField] VisualEffect fivestarswordskillseven;

    [SerializeField] VisualEffect fivestarspearskillfirst;
    [SerializeField] VisualEffect fivestarspearskillsecond;
    [SerializeField] VisualEffect fivestarspearskillthree;
    [SerializeField] VisualEffect fivestarspearskillfour;
    [SerializeField] VisualEffect fivestarspearskillfive;
    [SerializeField] VisualEffect fivestarspearskillsix;
    #endregion

    #region ƒ›∂Û¿Ã¥ıµÈ
    [SerializeField] GameObject onestarswordcol;
    [SerializeField] GameObject onestarspearcol;
    [SerializeField] GameObject twostarswordcol;
    [SerializeField] GameObject twostarspearcol;
    [SerializeField] GameObject threestarswordcol;
    [SerializeField] GameObject threestarspearcol;
    [SerializeField] GameObject fourstarswordcol;
    [SerializeField] GameObject fourstarspearcol;
    [SerializeField] GameObject fivestarswordcol;
    [SerializeField] GameObject fivestarspearcol;
    #endregion

    [SerializeField] PlayableDirector swordplayableDirector;
    [SerializeField] PlayableDirector spearplayabledirector;

    [SerializeField] GameObject activeskillcooltimeui;

    private AudioSource audiosource;
    [SerializeField] AudioClip[] audioclip;

    WaitForSeconds a = new WaitForSeconds(0.1f);

    
    
    private float skillcooltime = 0f;
    private float nowskillcooltime = 0f;

    private float swordcooltime = 0.8f;
    private float spearcooltime = 0.5f;

    private float activeskillcooltime = 15f;
    private float specialskillcooltime = 35f;

    PlayerJsonData data; 

    public void Awake()
    {
        audiosource = GetComponent<AudioSource>();

        data = DataManager.LoadJsonFile<PlayerJsonData>(Application.dataPath + "/SAVE/Player", "User");

        if (data.weaponStat.id <= 4 )
        {
            nowskillcooltime = swordcooltime;
        }
        else if(data.weaponStat.id >= 5 && data.weaponStat.id <= 9)
        {
            nowskillcooltime = spearcooltime;
        }

        #region ¿Ã∆Â∆Æ ∏ÿ√„
        onestarswordskill.Stop();

        onestarspearskill.Stop();

        twostarswordskillfirst.Stop();
        twostarswordskillsecond.Stop();
        twostarswordskillthird.Stop();

        twostarspearskillfirst.Stop();
        twostarspearskillsecond.Stop();

        threestarswordskillfirst.Stop();
        threestarswordskillsecond.Stop();
        threestarswordskillthree.Stop();
        threestarswordskillfour.Stop();

        threestarspearskillfirst.Stop();
        threestarspearskillsecond.Stop();
        threestarspearskillthree.Stop();

        fourstarswordskillfirst.Stop();
        fourstarswordskillsecond.Stop();
        fourstarswordskillthree.Stop();
        fourstarswordskillfour.Stop();
        fourstarswordskillfive.Stop();
        fourstarswordskillsix.Stop();
        fourstarswordskillseven.Stop();


        fourstarspearskillfirst.Stop();
        fourstarspearskillsecond.Stop();
        fourstarspearskillthree.Stop();
        fourstarspearskillfour.Stop();
        fourstarspearskillfive.Stop();
        fourstarspearskillsix.Stop();

        fivestarswordskillfirst.Stop();
        fivestarswordskillsecond.Stop();
        fivestarswordskillthree.Stop();
        fivestarswordskillfour.Stop();
        fivestarswordskillfive.Stop();
        fivestarswordskillsix.Stop();
        fivestarswordskillseven.Stop();
        

        fivestarspearskillfirst.Stop();
        fivestarspearskillsecond.Stop();
        fivestarspearskillthree.Stop();
        fivestarspearskillfour.Stop();
        fivestarspearskillfive.Stop();
        fivestarspearskillsix.Stop();
        #endregion
    }


    public void Update()
    {
        skillcooltime += Time.deltaTime;
        activeskillcooltime += Time.deltaTime;
        specialskillcooltime += Time.deltaTime;

        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (activeskillcooltime > 15f)
            {
                
                if (data.weaponStat.id == 2)
                {
                    activeskillcooltimeui.SetActive(true);
                    activeskillUI.isactive = true;
                    threestarswordeffect.func();
                }
                else if (data.weaponStat.id == 7)
                {
                    activeskillcooltimeui.SetActive(true);
                    activeskillUI.isactive = true;
                    Threestarspeareffect.func();
                }
                else if (data.weaponStat.id == 3)
                {
                    activeskillcooltimeui.SetActive(true);
                    activeskillUI.isactive = true;
                    fourstarswordeffect.func();
                }
                else if (data.weaponStat.id == 8)
                {
                    activeskillcooltimeui.SetActive(true);
                    activeskillUI.isactive = true;
                    fourstarspeareffect.func();
                }
                else if (data.weaponStat.id == 4)
                {
                    activeskillcooltimeui.SetActive(true);
                    activeskillUI.isactive = true;
                    fivestarswordeffect.func();
                }
                else if (data.weaponStat.id == 9)
                {
                    activeskillcooltimeui.SetActive(true);
                    activeskillUI.isactive = true;
                    fivestarspeareffect.func();
                }
                activeskillcooltime = 0f;
            }
        }
        
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (specialskillcooltime > 35f)
            {
                if (data.weaponStat.id == 4)
                {
                    swordplayableDirector.Play();
                }
                else if (data.weaponStat.id == 9)
                {
                    spearplayabledirector.Play();
                }
                specialskillcooltime = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {

            if (skillcooltime > nowskillcooltime)
            {
                if (AgentSpriteRenderer._isflip == false)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (AgentSpriteRenderer._isflip == true)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                switch (data.weaponStat.id)
                {
                    case 0:
                        audiosource.clip = audioclip[1];
                        audiosource.Play();
                        StartCoroutine(onestarswordskillfunc());
                        break;
                    case 1:
                        audiosource.clip = audioclip[1];
                        audiosource.Play();
                        StartCoroutine(twostarswordskillfunc());
                        break;
                    case 2:
                        audiosource.clip = audioclip[1];
                        audiosource.Play();
                        StartCoroutine(threestarswordskillfunc());
                        break;
                    case 3:
                        audiosource.clip = audioclip[1];
                        audiosource.Play();
                        StartCoroutine(fourstarswordskillfunc());
                        break;
                    case 4:
                        audiosource.clip = audioclip[1];
                        audiosource.Play();
                        StartCoroutine(fivestarswordskillfunc());
                        break;
                    case 5:
                        audiosource.clip = audioclip[0];
                        audiosource.Play();
                        StartCoroutine(onestarspearskillfunc());
                        break;
                    case 6:
                        audiosource.clip = audioclip[0];
                        audiosource.Play();
                        StartCoroutine(twostarspearskillfunc());
                        break;
                    case 7:
                        audiosource.clip = audioclip[0];
                        audiosource.Play();
                        StartCoroutine(threestarspearskillfunc());
                        break;
                    case 8:
                        audiosource.clip = audioclip[0];
                        audiosource.Play();
                        StartCoroutine(fourstarspearskillfunc());
                        break;
                    case 9:
                        audiosource.clip = audioclip[0];
                        audiosource.Play();
                        StartCoroutine(fivestarspearskillfunc());
                        break;

                }
                skillcooltime = 0f;

            }
        }
    }

    public void SwordSound()
    {
        audiosource.clip = audioclip[2];
        audiosource.Play();
    }
    public void SpearSound()
    {
        audiosource.clip = audioclip[3];
        audiosource.Play();
    }
    public void SpearWeaponSound()
    {
        audiosource.clip = audioclip[0];
        audiosource.Play();
    }


    //public void SkillDamage

    IEnumerator onestarswordskillfunc()
    {
        onestarswordcol.SetActive(true);
        onestarswordskill.Play();
        yield return a;
        onestarswordcol.SetActive(false);
    }

    IEnumerator onestarspearskillfunc()
    {
        onestarspearcol.SetActive(true);
        onestarspearskill.Play();
        yield return a;
        onestarspearcol.SetActive(false);
    }

    IEnumerator twostarswordskillfunc()
    {
        twostarswordcol.SetActive(true);
        twostarswordskillfirst.Play();
        yield return a;
        twostarswordskillsecond.Play();
        yield return a;
        twostarswordskillthird.Play();
        twostarswordcol.SetActive(false);
    }

    IEnumerator twostarspearskillfunc()
    {
        twostarspearcol.SetActive(true);
        twostarspearskillfirst.Play();
        yield return a;
        twostarspearskillsecond.Play();
        twostarspearcol.SetActive(false);

    }

    IEnumerator threestarswordskillfunc()
    {
        threestarswordcol.SetActive(true);
        threestarswordskillfirst.Play();
        yield return a;
        threestarswordskillsecond.Play();
        yield return a;
        threestarswordskillthree.Play();
        yield return a;
        threestarswordskillfour.Play();
        threestarswordcol.SetActive(false);
        
    }
    
    IEnumerator threestarspearskillfunc()
    {
        threestarspearcol.SetActive(true);
            threestarspearskillfirst.Play();
            yield return a;
            threestarspearskillsecond.Play();
            yield return a;
            threestarspearskillthree.Play();
            yield return a;
        threestarspearcol.SetActive(false);

    }

    IEnumerator fourstarswordskillfunc()
    {
        fourstarswordcol.SetActive(true);
        fourstarswordskillfirst.Play();
        yield return a;
        fourstarswordskillsecond.Play();
        yield return a;
        fourstarswordskillthree.Play();
        yield return a;
        fourstarswordskillfour.Play();
        yield return a;
        fourstarswordskillfive.Play();
        fourstarswordskillsix.Play();
        fourstarswordskillseven.Play();
        fourstarswordcol.SetActive(false);

    }

    IEnumerator fourstarspearskillfunc()
    {
        fourstarspearcol.SetActive(true);
        fourstarspearskillfirst.Play();
        yield return a;
        fourstarspearskillsecond.Play();
        yield return a;
        fourstarspearskillthree.Play();
        yield return a;
        fourstarspearskillfour.Play();
        yield return a;
        fourstarspearskillfive.Play();
        yield return a;
        fourstarspearskillsix.Play();
        fourstarspearcol.SetActive(false);
    }

    IEnumerator fivestarswordskillfunc()
    {
        fivestarswordcol.SetActive(true);
        fivestarswordskillfirst.Play();
        yield return a;
        fivestarswordskillsecond.Play();
        yield return a;
        fivestarswordskillthree.Play();
        yield return a;
        fivestarswordskillfour.Play();
        yield return a;
        fivestarswordskillfive.Play();
        fivestarswordskillsix.Play();
        fivestarswordskillseven.Play();
        fivestarswordcol.SetActive(false);
    }

    IEnumerator fivestarspearskillfunc()
    {
        fivestarspearcol.SetActive(true);
        fivestarspearskillfirst.Play();
        yield return a;
        fivestarspearskillsecond.Play();
        yield return a;
        fivestarspearskillthree.Play();
        yield return a;
        fivestarspearskillfour.Play();
        yield return a;
        fivestarspearskillfive.Play();
        yield return a;
        fivestarspearskillsix.Play();
        fivestarspearcol.SetActive(false);
    }


}
