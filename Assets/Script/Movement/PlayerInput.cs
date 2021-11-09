using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerData playerData;

    private void Start() => playerData = PlayerController.instance.playerdata;
    
    void Update()
    {
        //Walking
        playerData.horizontalAxis = Input.GetAxis("Horizontal");

        //Duck
        if(Input.GetKey(playerData.Duck))
             playerData.Buttons |= InputButtons.Duck;
        else
            playerData.Buttons &= ~InputButtons.Duck;
        
        //Jump
        if(Input.GetKey(playerData.Jump))
             playerData.Buttons |= InputButtons.Jump;
        else
            playerData.Buttons &= ~InputButtons.Jump;

        playerData.OldButtons = playerData.Buttons;
    }
}
