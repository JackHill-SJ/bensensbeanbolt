using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static Action OnGameFinished;
    public static Action OnVolumeUpdate;
    const string SKIN_PREF = "SkinIndex";
    const string VOLUME_PREF = "Volume";

    [Range(0, 10)] public int Skin;
    public Sprite[] SkinSprites;
    [HideInInspector] [Range(0, 1)] public float Volume;

    public float SpeedIncreasePercentagePerSecond;

    private void Awake() => Instance = this;
    private void Start()
    {
        Skin = PlayerPrefs.GetInt(SKIN_PREF, 0);
        Volume = PlayerPrefs.GetFloat(VOLUME_PREF, 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void RunEnd() => OnGameFinished?.Invoke();
    public void SelectSkin()
    {
        PlayerPrefs.SetInt(SKIN_PREF, Skin);
    }
    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        Volume = volume;
        PlayerPrefs.SetFloat(VOLUME_PREF, Volume);
        OnVolumeUpdate?.Invoke();
    }
}