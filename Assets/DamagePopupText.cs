using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamagePopupText : MonoBehaviour
{

    private float Destroytime = 0.5f;



    void Start()
    {
        Destroy(gameObject,Destroytime);
    }
}
