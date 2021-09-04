using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static Action OnGameFinished;

    public float SpeedIncreasePercentagePerSecond;

    private void Awake() => Instance = this;
    private void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void RunEnd() => OnGameFinished?.Invoke();
}