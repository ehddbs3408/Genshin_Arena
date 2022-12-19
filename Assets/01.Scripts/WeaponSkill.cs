using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WeaponSkill : MonoBehaviour
{
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


    public static int weaponskillnum = 1;

    WaitForSeconds a = new WaitForSeconds(0.1f);

    private float skillcooltime = 0f;
    private float nowskillcooltime = 0f;
    private float swordcooltime = 5f;
    private float spearcooltime = 1f;

    

    public void Start()
    {

        if (weaponskillnum / 2 == 0)
        {
            nowskillcooltime = spearcooltime;
        }
        else if(weaponskillnum / 2 != 0)
        {
            nowskillcooltime = swordcooltime;
        }

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

        //½ºÀ§Ä¡ ¹®À¸·Î ¹Ù²ãÁÜ + ½ºÅ³ ÄðÅ¸ÀÓµµ
    }


    public void Update()
    {
        skillcooltime += Time.deltaTime;
        if (skillcooltime > nowskillcooltime)
        {
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (AgentSpriteRenderer._isflip == false)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if(AgentSpriteRenderer._isflip == true)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                switch (weaponskillnum)
                {
                    case 1:
                        StartCoroutine(onestarswordskillfunc());
                        break;
                    case 2:
                        StartCoroutine(onestarspearskillfunc());
                        break;
                    case 3:
                        StartCoroutine(twostarswordskillfunc());
                        break;
                    case 4:
                        StartCoroutine(twostarspearskillfunc());
                        break;
                    case 5:
                        StartCoroutine(threestarswordskillfunc());
                        break;
                    case 6:
                        StartCoroutine(threestarspearskillfunc());
                        break;
                    case 7:
                        StartCoroutine(fourstarswordskillfunc());
                        break;
                    case 8:
                        StartCoroutine(fourstarspearskillfunc());
                        break;
                    case 9:
                        StartCoroutine(fivestarswordskillfunc());
                        break;
                    case 10:
                        StartCoroutine(fivestarspearskillfunc());
                        break;
                }
                skillcooltime = 0f;
            }
            
        }
    }

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
