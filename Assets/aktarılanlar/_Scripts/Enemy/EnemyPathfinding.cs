using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float move_Speed;
    private Rigidbody2D rb_path;
    private Vector2 move_Dir;
    private Knockback knockback_pf;
    private SpriteRenderer spriteRenderer_;

    private void Awake()
    {
        spriteRenderer_ = GetComponent<SpriteRenderer>();
        knockback_pf = GetComponent<Knockback>();
        rb_path = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        if(knockback_pf.Getting_KnockedBack) { return; }

        rb_path.MovePosition(rb_path.position + move_Dir * (move_Speed * Time.fixedDeltaTime));

        if (move_Dir.x < 0)
        {
            spriteRenderer_.flipX = true;
        }
        else if (move_Dir.x > 0)
        {
            spriteRenderer_.flipX = false;
        }
    }




    public void Move_To(Vector2 targetPos)
    {
        move_Dir = targetPos;
    }



    public void Stop_Moving()
    {
        move_Dir = Vector3.zero;
    }

}
