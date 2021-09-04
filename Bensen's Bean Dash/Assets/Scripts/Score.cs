using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    const string SCORE = "HighScore";
    public Text HighText;
    public Text ScoreText;

    string highStartText;
    string scoreStartText;
    [HideInInspector] public float score = 0;

    private void Awake()
    {
        Instance = Instance ?? this;
        GameManager.OnGameFinished -= OnLose;
        GameManager.OnGameFinished += OnLose;
    }
    private void OnDestroy()
    {
        Instance = Instance == this ? null : Instance;
        GameManager.OnGameFinished -= OnLose;
    }
    private void Start()
    {
        highStartText = HighText.text;
        scoreStartText = ScoreText.text;

        HighText.text = $"{highStartText} {PlayerPrefs.GetInt(SCORE, 0)}";
        AddScore(0);
    }
    public void AddScore(float x)
    {
        score += x;
        ScoreText.text = $"{scoreStartText} {Mathf.RoundToInt(score)}";
    }
    void OnLose()
    {
        PlayerPrefs.SetInt(SCORE, Mathf.RoundToInt(score));
    }
}