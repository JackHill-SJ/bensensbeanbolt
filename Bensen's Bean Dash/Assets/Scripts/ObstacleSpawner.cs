using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public enum TileType { Empty, Random }
    public int Speed;
    public GameObject[] Tiles = new GameObject[0];
    List<GameObject> children = new List<GameObject>();
    public int tileLength = 10;
    public int tileCount = 10;

    private void Start()
    {
        int position = 0;
        for (int i = tileCount; i > 0; i--)
        {
            position += tileLength;
            CreateTile(position, TileType.Empty);
        }
    }
    private void OnDestroy()
    {
        children = null;
    }
    private void Update()
    {
        foreach (GameObject gO in children) gO.transform.position += Vector3.back * Time.deltaTime * Speed;

        if (children[0].transform.position.z < -(tileLength * 1.5f))
        {
            float position = children[0].transform.position.z;
            Destroy(children[0]);
            children.RemoveAt(0);
            CreateTile(position + (tileLength * tileCount), TileType.Random);
        }
    }
    void CreateTile(float position, TileType type)
    {
        GameObject temp = new GameObject();
        temp.transform.parent = transform;
        temp.transform.position = Vector3.forward * position;
        children.Add(temp);
    }
}