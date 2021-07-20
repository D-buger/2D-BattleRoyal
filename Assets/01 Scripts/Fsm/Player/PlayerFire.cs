using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : FsmState<Player>
{

    public override void Enter(Player target)
    {
        //Debug.Log("PlayerState : Fire");
    }

    public override void Exit(Player target)
    {
    }

    public override void FixedUpdate(Player target)
    {
        target.model.Gun.Shot();
    }

    public override void HandleInput(Player target)
    {
        target.StateRevert();
    }

    public override void Once(Player target)
    {
    }

    public override void Update(Player target)
    {

    }
}
