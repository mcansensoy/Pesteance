using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private Player player;
    public Vector2 direction_;
    void Update()
    {
        FaceMouse();
    }


    private void FaceMouse()
    {
        /*if(!player.facingRight){
            transform.Rotate(180,0,0);
        }*/
        Vector3 mouse_Pos = Input.mousePosition;
        mouse_Pos = Camera.main.ScreenToWorldPoint(mouse_Pos);

        direction_ = transform.position - mouse_Pos;
        
        transform.right = -direction_;
        
    }
}
