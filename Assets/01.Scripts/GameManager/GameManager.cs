using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Camera MainCam;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Mutiple GameManger");
        }
        Instance = this;

        MainCam = Camera.main;
    }
}
