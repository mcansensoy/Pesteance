using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleton : Singleton<BaseSingleton>
{
    public override void Awake()
    {
        //BaseSingleton[] instances = FindObjectsOfType<BaseSingleton>();

        //if (instances.Length > 1)
        //{
        //    Destroy(gameObject);
        //}

        DontDestroyOnLoad(gameObject);
    }
}
