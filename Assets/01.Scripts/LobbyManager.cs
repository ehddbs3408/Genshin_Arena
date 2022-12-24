using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] GameObject Setting;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Setting.SetActive(true);
        }
    }
}
