using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : FsmState<Player>
{
    public override void Enter(Player target)
    {
        //Debug.Log("PlayerState : Idle");
    }

    public override void Exit(Player target)
    {

    }

    public override void FixedUpdate(Player target)
    {

    }

    public override void HandleInput(Player target)
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            target.ChangeState(ePlayerState.Move);
        }
        if(SystemManager.Inst.mouse.mouseState == eMouse.Down ||
            SystemManager.Inst.mouse.mouseState == eMouse.Drag
            )
        {
            target.ChangeState(ePlayerState.Fire);
        }
    }

    public override void Once(Player target)
    {

    }

    public override void Update(Player target)
    {

    }
}
