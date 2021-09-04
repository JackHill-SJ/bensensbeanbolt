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

    [System.Serializable] public struct Info
    {
        public AudioClip Clip;
        public string TriggerName;
    }
}