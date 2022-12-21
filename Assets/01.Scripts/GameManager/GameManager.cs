using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
