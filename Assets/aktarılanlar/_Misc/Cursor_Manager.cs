using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor_Manager : MonoBehaviour
{
    private Image cursor_image;

    private void Awake()
    {
        cursor_image = GetComponent<Image>();
    }

    void Start()
    {
        Cursor.visible = false;

        if (Application.isPlaying)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }


    void Update()
    {
        Vector2 cursor_Pos = Input.mousePosition;
        cursor_image.rectTransform.position = cursor_Pos;

        if(!Application.isPlaying) { return; }

        Cursor.visible = false;
    }
}
