using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Thunder : MonoBehaviour
{
    public Info[] info = new Info[2];
    Animator a;
    AudioSource aS;
    int index;

    private void Awake()
    {
        GameManager.OnVolumeUpdate -= OnSoundChanged;
        GameManager.OnVolumeUpdate += OnSoundChanged;
    }
    private void OnDestroy()
    {
        GameManager.OnVolumeUpdate -= OnSoundChanged;
    }
    void Start()
    {
        a = GetComponent<Animator>();
        aS = gameObject.AddComponent<AudioSource>();
        Choose();
    }
    void Choose()
    {
        index = Random.Range(0, info.Length);
        Invoke(nameof(DoAnim), Random.Range(3f, 10f));
    }

    void DoAnim()
    {
        a.SetTrigger(info[index].TriggerName);
        Invoke(nameof(DoSound), Random.Range(0f, 3f));
    }
    void DoSound()
    {
        aS.PlayOneShot(info[index].Clip);
        Choose();
    }
    void OnSoundChanged()
    {
        aS.volume = GameManager.Instance.Volume;
    }
    [System.Serializable] public struct Info
    {
        public AudioClip Clip;
        public string TriggerName;
    }
}