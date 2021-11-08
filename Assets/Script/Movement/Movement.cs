using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    public PlayerData m_pd;

    public Rigidbody2D rb;
    
    public Movement(Rigidbody2D rbody, PlayerData playerdata)
    {
        rb = rbody;
        m_pd  = playerdata;
    }

    public void UpdateMoveProcess()
    { 
        
    }

    private void Jump()
    {
        m_pd.isGrounded = false;
        m_pd._playerVel.y = m_pd.JumpForce;
    }

    public void GroundMove()
    {

    }
    
}
