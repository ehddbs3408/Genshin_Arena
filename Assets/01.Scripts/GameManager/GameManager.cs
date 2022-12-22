using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject backtomenu;
    [SerializeField] private GameObject setting;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if(PausePanel.activeSelf == true && backtomenu.activeSelf == false && setting.activeSelf == false)
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            if(PausePanel.activeSelf == false)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            
            
            if (setting.activeSelf == true && PausePanel.activeSelf == true)
            {
                setting.SetActive(false);
            }
            else if(backtomenu.activeSelf == true && PausePanel.activeSelf == true)
            {
                backtomenu.SetActive(false);
            }
            
            
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
