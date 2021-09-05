using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Beans : MonoBehaviour
{
    const int PLAYER_LAYER = 3;
    public int ScoreAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == PLAYER_LAYER)
        {
            Score.Instance.AddScore(ScoreAmount);
            Destroy(gameObject);
        }
    }
}