using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetItemController : MonoBehaviour
{
    private int isGameOver;

    private Transform paenl;

    [SerializeField]
    private TextMeshProUGUI _drawingText;

    [SerializeField]
    private TextMeshProUGUI _1stText;
    [SerializeField]
    private TextMeshProUGUI _2stText;
    [SerializeField]
    private TextMeshProUGUI _3stText;
    [SerializeField]
    private TextMeshProUGUI _4stText;
    [SerializeField]
    private TextMeshProUGUI _5stText;

    [SerializeField]
    private Slider _expSlider;
    [SerializeField]
    private TextMeshProUGUI _levelText;



    private int _1st = 0;
    private int _2st = 0;
    private int _3st = 0;
    private int _4st = 0;
    private int _5st = 0;

    private Jaereonitem itemlist;
    private void Awake()
    {
        itemlist = DataManager.LoadJsonFile<Jaereonitem>(Application.dataPath + "/SAVE/Weapon", "Jaereonitem");
        paenl = transform.Find("Panel").GetComponent<Transform>();
    }
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        isGameOver = PlayerPrefs.GetInt("GameOver",0);
        if (isGameOver == 0)
        {
            paenl.gameObject.SetActive(false);
            return;
        }
        paenl.gameObject.SetActive(true);
        PlayerPrefs.SetInt("GameOver", 0);

        GetItem();
    }

    private void GetItem()
    {
        EnemyKillJsonData data = DataManager.LoadJsonFile<EnemyKillJsonData>(Application.dataPath + "/SAVE/Wave", "KillData");
        int cnt = 0;
        foreach(EnemyKill kill in data.enemyKillList)
        {
            GetItem(kill.wave, kill.killEnemyCnt);
            cnt += kill.killEnemyCnt;
        }

        GetDrawingItem(cnt);

        SetText();
    }
    private void SetText()
    {
        _1stText.text = _1st.ToString();
        _2stText.text = _2st.ToString();
        _3stText.text = _3st.ToString();
        _4stText.text = _4st.ToString();
        _5stText.text = _5st.ToString();
    }

    private void GetDrawingItem(int cnt)
    {
        int chance = 10;
        int count = 0;
        for (int i = 0; i < cnt; i++)
        {
            int a = Random.Range(0, 100);
            if (a < chance)
                count++;
        }
        _drawingText.text = count.ToString();
        PlayerPrefs.SetInt("Drawing", count);
    }

    private void GetItem(int wave,int cnt)
    {
        int chance = GetChance(wave);
        int count = 0;
        for(int i = 0;i<cnt;i++)
        {
            int a = Random.Range(0, 100);
            if (a < chance)
                count++;
        }
        SaveStart(wave, count);
        Save(wave - 1, count);
    }

    private void Save(int starIdx,int cnt)
    {
        Jeareon jeareon = null;
        for (int i = 0; i < itemlist.list.Count; i++)
        {
            if (itemlist.list[i].reforgestarlevel == starIdx)
            {
                jeareon = itemlist.list[i];
                itemlist.list[i].cnt+= cnt;
                break;
            }
        }

        if (jeareon == null)
        {
            jeareon = new Jeareon();
            jeareon.reforgestarlevel = starIdx;
            jeareon.cnt = cnt;
            itemlist.list.Add(jeareon);
        }

        string json = DataManager.ObjectToJson(itemlist);
        DataManager.SaveJsonFile(Application.dataPath + "/SAVE/Weapon", "Jaereonitem", json);
    }

    private void SaveStart(int wave,int cnt)
    {
        switch (wave)
        {
            case 1:
                _1st = cnt;
                break;
            case 2:
                _2st = cnt;
                break;
            case 3:
                _3st = cnt;
                break;
            case 4:
                _4st = cnt;
                break;
            case 5:
                _5st = cnt;
                break;
        }
    }

    private int GetChance(int wave)
    {
        int chance = 0;
        switch(wave)
        {
            case 1:
                chance = 20;
                break;
            case 2:
                chance = 20;
                break;
            case 3:
                chance = 20;
                break;
            case 4:
                chance = 20;
                break;
            case 5:
                chance = 20;
                break;
        }

        return chance;
    }
}
