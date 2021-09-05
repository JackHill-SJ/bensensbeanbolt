using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float Speed;
    public bool Go = false;
    void Update()
    {
        if (Go) transform.position += Vector3.back * Time.deltaTime * Speed;
    }
}