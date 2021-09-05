using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    Slider s;
    float storedVolume;
    private void Start()
    {
        s = GetComponent<Slider>();
        storedVolume = GameManager.Instance.Volume;
        s.value = storedVolume;
    }
    private void Update()
    {
        if (storedVolume != s.value)
        {
            storedVolume = s.value;
            GameManager.Instance.SetVolume(storedVolume);
        }
    }
}