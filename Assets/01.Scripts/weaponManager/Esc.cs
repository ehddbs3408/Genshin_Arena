using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour
{
    [SerializeField] GameObject a;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(a.gameObject.activeSelf == true)
            {
                a.gameObject.SetActive(false);
            }
            else if(a.gameObject.activeSelf == false)
            {
                transform.gameObject.SetActive(false);
            }
            
        }
    }
    
}
