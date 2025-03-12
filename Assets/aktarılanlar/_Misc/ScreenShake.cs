using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : Singleton<ScreenShake>
{
    private CinemachineImpulseSource impulse_listener;

    public override void Awake()
    {
        base.Awake();

        impulse_listener = GetComponent<CinemachineImpulseSource>();
    }


    public void Shake_Screen()
    {
        impulse_listener.GenerateImpulse();
    }
}
