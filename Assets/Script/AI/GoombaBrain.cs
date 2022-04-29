using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaBrain : MonoBehaviour
{
    public float speed = 5f;
    private bool isMovingRight = true;
    public Transform groundDetection;

    // Update is called once per frame
    void Update()
    {
        //What moving the Object
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Ground Detection
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 10f);

        //Is Ground Check hiting ground? No then we must turn the other direction
        if(!groundInfo.collider)
        {
            //Logic to know if we moving Right or left to Rotate  appropriately
            if(isMovingRight)
            {
                transform.eulerAngles = new Vector3( 0, 180f, 0);
                isMovingRight = false;
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
                isMovingRight = true;
            }
        }
    }
}
