using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    IHittable hit;
    IStun stun;
    IKnockBack knockBack;

    private void Awake()
    {
        hit = GameObject.Find("Player").GetComponent<IHittable>();
        stun = GameObject.Find("Player").GetComponent<IStun>();
        knockBack = GameObject.Find("Player").GetComponent<IKnockBack>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            hit.OnGethit(10, this.gameObject);
            stun.OnGetStun(100, 0.2f);
            knockBack.OnGetKnockBack(Vector3.right, 10, 1, this.gameObject);
        }
    }
}
