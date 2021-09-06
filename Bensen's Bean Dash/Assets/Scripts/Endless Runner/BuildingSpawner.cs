using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public enum Side { Left, Right }
    public float Speed;
    public GameObject[] Tiles = new GameObject[0];
    List<GameObject> leftChildren = new List<GameObject>();
    List<GameObject> rightChildren = new List<GameObject>();
    public int tileLength = 10;
    public int tileCount = 10;

    private void Awake()
    {
        GameManager.OnGameFinished -= OnPlayerLose;
        GameManager.OnGameFinished += OnPlayerLose;
    }
    private void OnDestroy()
    {
        GameManager.OnGameFinished -= OnPlayerLose;
        leftChildren = null;
        rightChildren = null;
    }
    private void Start()
    {
        int position = 0;
        for (int i = tileCount; i > 0; i--)
        {
            position += tileLength;
            CreateTile(position, leftChildren, Side.Left);
            CreateTile(position, rightChildren, Side.Right);
        }
    }
    private void Update()
    {
        MoveChildren(leftChildren, Side.Left);
        MoveChildren(rightChildren, Side.Right);
        Speed += Speed * Time.deltaTime * GameManager.Instance.SpeedIncreasePercentagePerSecond;
    }
    void MoveChildren(List<GameObject> list, Side side)
    {
        foreach (GameObject gO in list) gO.transform.position += Vector3.back * Time.deltaTime * Speed;

        if (list[0].transform.position.z < -(tileLength * 1.5f))
        {
            float position = list[0].transform.position.z;
            Destroy(list[0]);
            list.RemoveAt(0);
            CreateTile(position + (tileLength * tileCount), list, side);
        }
    }
    void CreateTile(float position, List<GameObject> list, Side side)
    {
        GameObject temp = Instantiate(Tiles[Random.Range(0, Tiles.Length)]);
        temp.transform.parent = transform;
        temp.transform.position = Vector3.forward * position;
        temp.transform.position = (side == Side.Left ? Vector3.left : Vector3.right) * 15;
        list.Add(temp);
    }
    void OnPlayerLose()
    {
        Destroy(this);
    }
}