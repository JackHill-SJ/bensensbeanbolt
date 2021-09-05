using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * Speed;
    }
}