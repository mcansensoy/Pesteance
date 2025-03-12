using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private GameObject activeWeapon_f;
    private SpriteRenderer sp_re;


    [Header("Move Info")]
    public float moveSpeed = 8f;

    public int FacingDir { get; private set; }
    public bool facingRight = true;
    public float dashSpeed;
    public float dashDuration;

    #region components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerControls playerControl { get; private set; }
    public Vector3 mousePos;

    #endregion

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerDashState DashState { get; private set; }

    //public UpIdleState upIdleState { get; private set; }
    //public UpRunState upRunState { get; private set; }

    #endregion

    public Vector2 xd;

    public override void Awake() 
    {
        base.Awake();

        StateMachine = gameObject.AddComponent<PlayerStateMachine>();
        playerControl = new PlayerControls();
        
        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        DashState = new PlayerDashState(this, StateMachine, "Dash");
        //upIdleState = new UpIdleState(this, stateMachine, "UpIdle");
        //upRunState = new UpRunState(this, stateMachine, "UpRun");
    }

    private void Start() 
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        xd = new Vector2(0f,0f);
        sp_re = GetComponent<SpriteRenderer>();
        
        StateMachine.Initialize(IdleState);
    }

    private void OnEnable() 
    {
        playerControl.Enable();
    }

    private void Update() 
    {        
        StateMachine.currentState.Update();
        CheckForDash();
    }

    private void FixedUpdate() 
    {
        //PlayerFaceDirection();
        Adjust_Player_facingDirection();
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

    //public void Flip()
    //{
    //    facingDir = facingDir * -1;
    //    facingRight = !facingRight;
    //    transform.Rotate(0, 180, 0);
    //}



    private void Adjust_Player_facingDirection()
    {
        //Vector2 mouseVec2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mySpriteRenderer.flipX = (mouseVec2 - rb.position).x < 0;

        Vector3 mousePos = Input.mousePosition;
        Vector3 player_Point = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 newRotation_0 = activeWeapon_f.transform.eulerAngles;
        Vector3 newRotation = activeWeapon_f.transform.eulerAngles;
        newRotation_0.y = 0f;
        newRotation.y = 180f;

        if (mousePos.x < player_Point.x)
        {
            sp_re.flipX = true;
            
            activeWeapon_f.transform.eulerAngles = newRotation;
            facingRight = false;
        }
        else
        {
            sp_re.flipX = false;

            activeWeapon_f.transform.eulerAngles = newRotation_0;
            facingRight = true;
        }
    }



    //private void PlayerFaceDirection(){
    //    Vector3 mousePos = Input.mousePosition;
    //    //Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
    //    //Mathf.Abs(worldMousePosition.x) > Mathf.Abs(worldMousePosition.y)

    //    Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
    //    //Vector2 dashDirection = (mousePos - playerScreenPoint).normalized;

    //    if(mousePos.x < playerScreenPoint.x && facingRight){
    //        Flip();
    //    }
    //    else if(mousePos.x > playerScreenPoint.x && !facingRight){
    //        Flip();
    //    }   
    //}

    private void CheckForDash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dash.CanUseSkill())
        {
            StateMachine.ChangeState(DashState);
        }
    }
}
