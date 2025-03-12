using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Rigidbody2D rb;
    protected float stateTimer;
    

    public Vector2 moveInput;
    //protected float xInput;
    //protected float yInput;
    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName){
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter(){
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
    }

    public virtual void Update(){
        stateTimer -= Time.deltaTime;
        moveInput = player.playerControl.Player.Move.ReadValue<Vector2>();
    }

    public virtual void Exit(){
        player.anim.SetBool(animBoolName, false);
    }
}
