using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private List<GameObject> List = new List<GameObject>();
    protected override void Init()
    {
        base.Init();

        //GameObject go = Managers.Resource.Load<GameObject>("Prefabs/asd");

        //List<GameObject> List = new List<GameObject>();

        //Managers.Pool.CreatePool(go, 10);

        //for (int i = 0; i < 10; i++)
        //{
        //    List.Add(Managers.Resource.Instantiate("asd"));
        //}

        //Managers.Resource.Destroy(List[0]);
        //List.RemoveAt(0);
        //게임 시작시
    }
    public override void Clear()
    {

    }
}
