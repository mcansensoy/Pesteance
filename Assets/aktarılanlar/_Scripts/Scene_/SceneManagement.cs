using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : Singleton<SceneManagement>
{
    public string Scene_teleport_Name { get; private set; }


    public void SetTransition_Name(string scene_teleport_Name_sm)
    {
        Scene_teleport_Name = scene_teleport_Name_sm;
    }
}
