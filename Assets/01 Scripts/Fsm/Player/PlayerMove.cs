using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : FsmState<Player>
{
    private Vector2 playerInput;

    public override void Enter(Player target)
    {
        //Debug.Log("PlayerState : Move");
    }

    public override void Exit(Player target)
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
            target.physics.MovingSet(Vector2.zero);
        }
    }

    public override void Update(Player target)
    {
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
    }

    public override void FixedUpdate(Player target)
    {
        target.physics.MovingSet(playerInput);
    }

    public override void HandleInput(Player target)
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            target.ChangeState(ePlayerState.Idle);
        }
        if (SystemManager.Inst.mouse.mouseState == eMouse.Down ||
            SystemManager.Inst.mouse.mouseState == eMouse.Drag
            )
        {
            target.ChangeState(ePlayerState.Fire);
        }
    }

    public override void Once(Player target)
    {

    }
    
}
