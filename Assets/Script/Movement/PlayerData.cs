using System;
using UnityEngine;

[Serializable]
public class PlayerData {
    
    [Header("Player Data")]
    public float Ground_Acceleration;
    public float max_Ground_Speed;
    public float Crouch_Accel;
    public float max_Crouch_Speed; 
    public float JumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public bool isGrounded = true;
    public LayerMask Ground;

    [Header("Physics")]
    public float GravityValue = -9.81f;
    public float GravityScale = 20f;
    [HideInInspector]public float gravityMultiplier = 1f;


    [Header("Input Data")]
    public float horizontalAxis = 0f;
    public KeyCode Duck = KeyCode.S;
    public KeyCode Jump = KeyCode.Space;
    public KeyCode Pause = KeyCode.Escape;
    public KeyCode Restart = KeyCode.R;
    public InputButtons Buttons;
    public InputButtons OldButtons;

    [Header("Other")]
    public Vector2 PlayerVelocity;
}