using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningNoiseGroundChecker : MonoBehaviour
{
    AudioSource aS;
    float lastVolume;
    bool toggled = false;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!Player.Instance.HasLost)
        {
            if (!toggled && !Player.Instance.OnGround)
            {
                toggled = true;
                lastVolume = aS.volume;
                aS.volume = 0;
            }
            else if (toggled && Player.Instance.OnGround)
            {
                toggled = false;
                aS.volume = lastVolume;
            }
        }
    }
}