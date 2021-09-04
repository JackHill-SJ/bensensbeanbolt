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
    [HideInInspector] public int score = 0;

    private void Awake() => Instance = Instance ?? this;
    private void OnDestroy() => Instance = Instance == this ? null : Instance;
    private void Start()
    {
        highStartText = HighText.text;
        scoreStartText = ScoreText.text;

        HighText.text = $"{highStartText} {PlayerPrefs.GetInt(SCORE, 0)}";
        AddScore(0);
    }
    public void AddScore(int x)
    {
        score += x;
        ScoreText.text = $"{scoreStartText} {score}";
    }
}