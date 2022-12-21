using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class fourstarspeareffect : MonoBehaviour
{
    public static Action func;
    private Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
        func = () =>
        {
            AnimPlay();
        };
    }

    public void AnimPlay()
    {
        anim.Play();
    }
}
