using System.Timers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    public PlayerData data;

    public Rigidbody2D rb;
        
    public Vector2 Velocity;
    public Movement(Rigidbody2D rbody, PlayerData playerdata)
    {
        rb = rbody;
        data  = playerdata;
    }

    public void UpdateMoveProcess()
    { 
        CalculateVelocity();

        rb.MovePosition(rb.position + Velocity * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        data.isGrounded = false;
        data._playerVel.y = data.JumpForce;
    }

    public void CalculateVelocity()
    {
        float x;
        float y;

        x = data.horizontalAxis * Time.deltaTime * data.Ground_Acceleration;
        y = rb.velocity.y;

        //the player is moving faster than max speed
        if(x > data.max_Ground_Speed)
            data.horizontalAxis = 0f;
                //So the player can't increase move speed and will slow down on its own

        Velocity = new Vector2(x, y);
    }
    
}
