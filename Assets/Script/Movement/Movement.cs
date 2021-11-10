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
            data.PlayerVelocity.y = 0f;

        if(data.Buttons.HasFlag(InputButtons.Jump) && data.isGrounded && data.canJump)
            Jump();

        ApplyJumpGravity();
        rb.MovePosition(rb.position + data.PlayerVelocity * Time.fixedDeltaTime);
    }

    public void UpdateInput()
    {
        data.horizontalAxis = Input.GetAxis("Horizontal");

    }
    private void Jump()
    {
        data.isGrounded = false;
        data.canJump = false;
        data.PlayerVelocity.y = data.JumpForce;
        PlayerController.instance.initJumpDelay();
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
    public void ApplyJumpGravity()
    {
        if(data.PlayerVelocity.y < 0)
        {
            data.PlayerVelocity += Vector2.up * Physics2D.gravity.y * (data.fallMultiplier - 1) * Time.deltaTime;
        }   
        else if(data.PlayerVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            data.PlayerVelocity += Vector2.up * Physics2D.gravity.y * (data.lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
