using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Singleton<PlayerMove>
{
    [SerializeField] float moveSpeed = 1f;
    private PlayerControls playerControls;
    private Vector2 moveInput;
    private Rigidbody2D rbody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRen;
    private Knockback knockback_;


    public override void Awake() {
        playerControls = new PlayerControls();
        rbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRen = GetComponent<SpriteRenderer>();
        knockback_ = GetComponent<Knockback>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }



    private void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate() {
        PlayerFaceDirection();
        Move();
    }






    void PlayerInput(){
        moveInput = playerControls.Player.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", moveInput.x);
        myAnimator.SetFloat("moveY", moveInput.y);
    }





    private void Move()
    {
        if (knockback_.Getting_KnockedBack || PlayerHealth.Instance_T.IsDead) { return; }
        else
        {
            rbody.MovePosition(rbody.position + moveInput * (moveSpeed * Time.fixedDeltaTime));
        }
    }

    private void PlayerFaceDirection(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if(mousePos.x < playerScreenPoint.x){
            mySpriteRen.flipX = true;
        }
        else{
            mySpriteRen.flipX = false;
        }
    }
}
