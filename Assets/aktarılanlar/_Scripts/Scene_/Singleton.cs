using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>: MonoBehaviour where T : Singleton<T>
{
    private static T instance_;
    public static T Instance_T { get { return instance_; } }

    public virtual void Awake()
    {
        if(instance_ !=null && this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance_ = (T)this;
        }

        if (!gameObject.transform.parent)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
