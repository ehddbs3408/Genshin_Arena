using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mapPrefab;

    [SerializeField]
    private float _xOffset;
    [SerializeField]
    private float _yOffset;

    [SerializeField]
    private int _mapSizeX;
    [SerializeField]
    private int _mapSizeY;

    private void Start()
    {
        CreateMap();
    }

    private void CreateMap()
    {
        for(int i = 0;i<_mapSizeX;i++)
        {
            for (int j = 0; j < _mapSizeY;j++)
            {
                GameObject go = Instantiate(mapPrefab, transform);
                go.transform.position = new Vector3(i * _xOffset + 1, -1, j * _yOffset+1);
            }
        }
        float posX, posY;
        posX = ((float)_mapSizeX * _xOffset) / 2;
        posY = ((float)_mapSizeY * _yOffset) / 2;
        transform.position = new Vector3(-posX, 0, -posY);
    }
}
