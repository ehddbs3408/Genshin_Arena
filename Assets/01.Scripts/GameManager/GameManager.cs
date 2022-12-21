using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
