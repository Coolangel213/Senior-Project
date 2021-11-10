using System;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] public PlayerData playerdata;
    private Movement playerMovement;
    private Rigidbody2D rb;
    //Initialize the Singleton
    private void Awake() => instance = this;


    //chache Variables
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = new Movement(rb, playerdata);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.UpdateInput();
        
        switch(playerdata.Buttons)
        {
            case InputButtons.Duck:
                //Change Sprite here

                break;
            case InputButtons.Jump:
                //Change Sprite Here

                break;
            default:
                //Player is walking
                break;
        }
    }

    private void FixedUpdate() {
        //Update Movement Process 
        playerMovement.UpdateMoveProcess();

    }


    private void OnCollisionStay2D(Collision2D coll)
    {
        //true = -1; false = 1
        if(coll.gameObject.layer.CompareTo(playerdata.Ground.value) < 0)
            playerdata.isGrounded = true;
    }
    internal void initJumpDelay()
    {
        Invoke("canJump", playerdata.delaybetweenJump);
    }
    void canJump() => playerdata.canJump = true;
}
