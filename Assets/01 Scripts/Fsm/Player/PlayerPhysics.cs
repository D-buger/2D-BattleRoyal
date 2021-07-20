using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics
{
    public PlayerPhysics(PlayerModel _model) => this.model = _model; 
    private PlayerModel model;

    private Vector2 velocity = Vector2.zero;
    private Vector2 desiredVelocity = Vector2.zero;

    public void PhysicsUpdate()
    {
        velocity = model.Body.velocity;
        
        float maxSpeedChange = model.GetAcceleration * model.GetMovementSpeed;

        velocity = Vector2.MoveTowards(velocity, desiredVelocity, maxSpeedChange);

        model.Body.velocity = velocity;
    }

    public void MovingSet(Vector2 input)
    {
        input = Vector2.ClampMagnitude(input, 1f);

        desiredVelocity = input * model.GetMovementSpeed;
    }


}
