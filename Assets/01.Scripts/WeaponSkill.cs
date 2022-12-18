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

    VisualEffect nowweapon;

    WaitForSeconds a = new WaitForSeconds(0.1f);
    WaitForSeconds b = new WaitForSeconds(0.06f);

    private float skillcooltime = 0f;
    private int count = 0;

    public void Start()
    {
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
        if (skillcooltime > 0.7f)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartCoroutine(fourstarspearskillfunc());
                skillcooltime = 0f;
            }
            
        }
    }

    IEnumerator twostarswordskillfunc()
    {
        twostarswordskillfirst.Play();
        yield return a;
        twostarswordskillsecond.Play();
        yield return a;
        twostarswordskillthird.Play();
    }

    IEnumerator twostarspearskillfunc()
    {
            
        twostarspearskillfirst.Play();
        yield return b;
        twostarspearskillsecond.Play();

    }

    IEnumerator threestarswordskillfunc()
    {
        threestarswordskillfirst.Play();
        yield return a;
        threestarswordskillsecond.Play();
        yield return a;
        threestarswordskillthree.Play();
        yield return a;
        threestarswordskillfour.Play();
        
    }
    
    IEnumerator threestarspearskillfunc()
    {
        
            threestarspearskillfirst.Play();
            yield return b;
            threestarspearskillsecond.Play();
            yield return b;
            threestarspearskillthree.Play();
            yield return b;
        
        
    }

    IEnumerator fourstarswordskillfunc()
    {
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

    }

    IEnumerator fourstarspearskillfunc()
    {
        fourstarspearskillfirst.Play();
        yield return b;
        fourstarspearskillsecond.Play();
        yield return b;
        fourstarspearskillthree.Play();
        yield return b;
        fourstarspearskillfour.Play();
        yield return b;
        fourstarspearskillfive.Play();
        yield return b;
        fourstarspearskillsix.Play();
    }

    IEnumerator fivestarswordskillfunc()
    {
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
    }

    IEnumerator fivestarspearskillfunc()
    {
        fivestarspearskillfirst.Play();
        yield return b;
        fivestarspearskillsecond.Play();
        yield return b;
        fivestarspearskillthree.Play();
        yield return b;
        fivestarspearskillfour.Play();
        yield return b;
        fivestarspearskillfive.Play();
        yield return b;
        fivestarspearskillsix.Play();
    }


}
