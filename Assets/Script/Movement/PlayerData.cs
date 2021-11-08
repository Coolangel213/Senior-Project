using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[Serializable]
public class PlayerData {
    
    [Header("Player Data")]
    public float MoveSpeed;
    public float JumpForce;
    public float CrounchSpeed; 
    public bool isGrounded = true;
    public LayerMask Ground;
    

    [Header("Input Data")]
    public float horizontalAxis = 0f;
    public KeyCode Duck = KeyCode.S;
    public KeyCode Jump = KeyCode.Space;
    public KeyCode Pause = KeyCode.Escape;
    public KeyCode Restart = KeyCode.R;
    public InputButtons Buttons;
    public InputButtons OldButtons;

    [Header("Movement Data")]
    public Vector3 _playerVel;
}