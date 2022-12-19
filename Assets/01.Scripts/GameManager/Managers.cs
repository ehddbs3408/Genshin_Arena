using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;
    static Managers Instance { get { Init(); return instance; } }

    #region CORE
    //Manager
    PoolManager _pool = new PoolManager();
    SceneManagerEX _scene = new SceneManagerEX();
    ResourceManagers _resource = new ResourceManagers();
    TimeManager _time = new TimeManager();
    //Property
    public static PoolManager Pool { get { return Instance._pool; } }
    public static SceneManagerEX Scene { get { return Instance._scene; } }
    public static ResourceManagers Resource { get { return Instance._resource; } }
    public static  TimeManager TimeMa { get { return Instance._time; } }
    #endregion

    #region Object
    private static Transform _playerTrm;
    public static Transform PlayerTrm 
    {
        get
        {
            if (_playerTrm == null)
            {
                _playerTrm = GameObject.Find("Player").GetComponent<Transform>();
            }
            return _playerTrm;
        }
    }
    #endregion


    private void Start()
    {
        Init();
    }
    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            instance = go.GetComponent<Managers>();

            instance._pool.Init();
            instance._time.Init();
        }
    }
    private void Update()
    {
        instance._time.OnUpdate(Time.deltaTime);
    }
    static void Clear()
    {
        Scene.Clear();


        Pool.Clear(); //항상 마지막에 클리어
    }
}
