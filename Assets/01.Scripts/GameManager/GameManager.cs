using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Transform _playerTrm;
    public Transform PlayerTrm 
    {
        get
        {
            if(_playerTrm == null)
            {
                _playerTrm = GameObject.Find("Player").transform;
            }
            return _playerTrm;
        }
    }

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
