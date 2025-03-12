using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
        Debug.Log("dash");
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void Update()
    {
        base.Update();

        /*rb.AddForce(player.dashDirection * player.dashSpeed, ForceMode2D.Impulse);*/
        rb.MovePosition(rb.position + moveInput * (player.dashSpeed * Time.fixedDeltaTime));

        if(stateTimer < 0){
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
