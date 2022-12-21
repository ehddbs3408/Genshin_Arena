using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI Hp;
    [SerializeField] TextMeshProUGUI Stamina;
    
    private int a = 25;
    private int b = 1000;
    private int c = 200;

    private void Start()
    {
        Level.text = "LV : " + a.ToString();
        Hp.text = "Hp : " + b.ToString();
        Stamina.text = "Stamina : " + c.ToString();
    }

    

    

}
