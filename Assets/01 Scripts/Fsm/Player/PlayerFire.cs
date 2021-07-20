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
        Vector2 shot = target.model.Gun.Shot();
        if (shot != Vector2.zero)
            target.physics.Shot(shot);
    }
}
