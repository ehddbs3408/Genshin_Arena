using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscSkillExplain : MonoBehaviour
{
    [SerializeField] GameObject[] list;

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
            for(int i = 0; i < list.Length; i++)
            {
                list[i].SetActive(false);
                
            }
            isclick++;
            if (isclick == 2)
            {
                transform.gameObject.SetActive(false);
                isclick = 0;
            }
        }
    }

}
