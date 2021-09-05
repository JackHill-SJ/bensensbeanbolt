using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInit : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.Instance == null) UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}