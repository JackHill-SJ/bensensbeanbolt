using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] Tiles = new GameObject[0];
    public int tileLength = 10;
    public int tileCount = 10;

    private void Start()
    {
        int position = tileLength * tileCount;
        for (int i = 0; i < tileCount; i++)
        {
            GameObject temp = new GameObject();
            temp.transform.parent = transform;
            temp.transform.position = Vector3.forward * position;
            position -= tileLength;
        }
    }
}