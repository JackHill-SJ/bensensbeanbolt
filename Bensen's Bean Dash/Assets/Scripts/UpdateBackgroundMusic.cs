using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBackgroundMusic : MonoBehaviour
{
    AudioSource[] aSs = new AudioSource[0];
    float[] baseVolume = new float[0];
    private void Awake()
    {
        GameManager.OnVolumeUpdate -= OnVolumeUpdated;
        GameManager.OnVolumeUpdate += OnVolumeUpdated;
    }
    private void OnDestroy()
    {
        GameManager.OnVolumeUpdate -= OnVolumeUpdated;
    }
    void Start()
    {
        aSs = GetComponents<AudioSource>();
        baseVolume = new float[aSs.Length];
        for (int i = 0; i < aSs.Length; i++)
        {
            baseVolume[i] = aSs[i].volume;
        }
    }
    void OnVolumeUpdated()
    {
        for (int i = 0; i < aSs.Length; i++)
        {
            aSs[i].volume = baseVolume[i] * GameManager.Instance.Volume;
        }
    }
}