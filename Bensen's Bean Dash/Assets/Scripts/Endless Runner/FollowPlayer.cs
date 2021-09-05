using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    void Update()
    {
        if (Player.Instance != null) transform.position = Vector3.Lerp(transform.position, Player.Instance.transform.position, .5f);
    }
}