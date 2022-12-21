using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        TimeSet();
    }

    private void TimeSet()
    {
        int time = (int)Managers.TimeMa.playTime;
        _text.text = string.Format("{0}:{1}", ((int)(time / 60)).ToString(), (time % 60).ToString());
    }
}
