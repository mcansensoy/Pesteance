using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    [SerializeField] private string fromDirectionLevelName;


    private void Start()
    {
        if (fromDirectionLevelName == SceneManagement.Instance_T.Scene_teleport_Name)
        {
            Player.Instance_T.transform.position = transform.position;
            CameraController.Instance_T.Set_PlayerCamera_Follow();


            UI_Fader.Instance_T.FadeTo_Clear();
        }
    }
}
