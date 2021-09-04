using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWaiter : MonoBehaviour
{
    [Range(0, 10)] public float Time;
    private void Awake() => GameManager.OnGameFinished += OnDeath;
    private void OnDestroy() => GameManager.OnGameFinished -= OnDeath;
    void OnDeath() => Invoke(nameof(ReturnToMain), Time);
    void ReturnToMain() => UnityEngine.SceneManagement.SceneManager.LoadScene(1);
}