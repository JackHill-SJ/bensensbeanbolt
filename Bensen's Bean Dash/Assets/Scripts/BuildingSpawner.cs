using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public float Speed;
    public GameObject[] Tiles = new GameObject[0];
    List<GameObject> leftChildren = new List<GameObject>();
    List<GameObject> rightChildren = new List<GameObject>();
    public int tileLength = 10;
    public int tileCount = 10;

    private void Start()
    {
        int position = 0;
        for (int i = tileCount; i > 0; i--)
        {
            position += tileLength;
            CreateTile(position, leftChildren);
            CreateTile(position, rightChildren);
        }
    }
    private void OnDestroy()
    {
        leftChildren = null;
        rightChildren = null;
    }
    private void Update()
    {
        MoveChildren(leftChildren);
        MoveChildren(rightChildren);
        Speed += Speed * Time.deltaTime * GameManager.Instance.SpeedIncreasePercentagePerSecond;
    }
    void MoveChildren(List<GameObject> list)
    {
        foreach (GameObject gO in list) gO.transform.position += Vector3.back * Time.deltaTime * Speed;

        if (list[0].transform.position.z < -(tileLength * 1.5f))
        {
            float position = list[0].transform.position.z;
            Destroy(list[0]);
            list.RemoveAt(0);
            CreateTile(position + (tileLength * tileCount), list);
        }
    }
    void CreateTile(float position, List<GameObject> list)
    {
        GameObject temp = new GameObject();
        temp.transform.parent = transform;
        temp.transform.position = Vector3.forward * position;
        list.Add(temp);
    }
}