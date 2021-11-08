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
        //Update Move Movement
        playerMovement.UpdateMoveProcess();
    }
}
