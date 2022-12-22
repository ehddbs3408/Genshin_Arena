using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    private Jaereonitem itemlist;
    private void Awake()
    {
        itemlist = DataManager.LoadJsonFile<Jaereonitem>(Application.dataPath + "/SAVE/Weapon", "Jaereonitem");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Save(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Save(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Save(2);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Save(3);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Save(4);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
             int drawing = PlayerPrefs.GetInt("Drawing");
            drawing++;
            PlayerPrefs.SetInt("Drawing", drawing);
        }
    }

    private void Save(int starIdx)
    {
        Jeareon jeareon = null;
        starIdx = starIdx > 5 ? starIdx - 5 : starIdx;
        for(int i = 0;i<itemlist.list.Count;i++)
        {
            if (itemlist.list[i].reforgestarlevel == starIdx)
            {
                jeareon = itemlist.list[i];
                itemlist.list[i].cnt++;
            }
        }

        if(jeareon == null)
        {
            jeareon = new Jeareon();
            jeareon.reforgestarlevel = starIdx;
            jeareon.cnt = 1;
            itemlist.list.Add(jeareon);
        }
        
        string json = DataManager.ObjectToJson(itemlist);
        DataManager.SaveJsonFile(Application.dataPath + "/SAVE/Weapon", "Jaereonitem", json);
    }
}
