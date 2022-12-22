using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffPanel : MonoBehaviour
{
    public void OnPanel(GameObject go)
    {
        go.SetActive(true);
    }

    public void OffPanel(GameObject go)
    {
        go.SetActive(false);
    }
}
