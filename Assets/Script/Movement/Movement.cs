using System.Timers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    public PlayerData data;
    public Rigidbody2D rb;
    public Movement(Rigidbody2D rbody, PlayerData playerdata)
    {
        rb = rbody;
        data  = playerdata;
    }

    public void UpdateMoveProcess()
    { 
        CalculateVelocity();

        if(data.PlayerVelocity.y < 0 && data.isGrounded)
        {
            data.PlayerVelocity.y = 0f;
            data.gravityMultiplier = 1f;
        }

        if(data.Buttons.HasFlag(InputButtons.Jump) && data.isGrounded)
            Jump();

        ApplyGravity();
        rb.MovePosition(rb.position + data.PlayerVelocity * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        data.isGrounded = false;
        data.PlayerVelocity = Vector2.up * data.JumpForce;
    }

    public void CalculateVelocity()
    {
        float x;
        x = data.horizontalAxis;

        if(data.Buttons.HasFlag(InputButtons.Duck))
        {

            x*= Time.fixedDeltaTime * data.Crouch_Accel;

            if(x > data.max_Crouch_Speed)
                x = data.max_Crouch_Speed;
            
            if(x < -data.max_Crouch_Speed)
                x = -data.max_Crouch_Speed;
        }
        else
        {
            x *= Time.fixedDeltaTime * data.Ground_Acceleration;
            
               if(x > data.max_Ground_Speed)
                x = data.max_Ground_Speed;
            
            if(x < -data.max_Ground_Speed)
                x = -data.max_Ground_Speed;
        }
        data.PlayerVelocity = new Vector2(x, data.PlayerVelocity.y);
    }
    public void ApplyGravity()
    {
        data.PlayerVelocity.y += data.GravityValue * data.GravityScale * data.gravityMultiplier * Time.deltaTime;

        if(rb.velocity.y < 0)
        {
            data.PlayerVelocity += Vector2.up * (data.GravityValue * data.GravityScale) * (data.fallMultiplier - 1) * Time.deltaTime;
            data.gravityMultiplier = (Time.fixedTime/Time.deltaTime) / 10;
        }
        else if(rb.velocity.y > 0 && data.Buttons.HasFlag(InputButtons.Jump) == false)
        {
            data.PlayerVelocity += Vector2.up * (data.GravityValue * data.GravityScale) * (data.lowJumpMultiplier - 1) * Time.deltaTime;
            data.gravityMultiplier = (Time.fixedTime/Time.deltaTime) / 10;
        }
    }
}
