using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyController : MonoBehaviour
{
    public Rigidbody rb;
    //public Vector2 move;
    public float moveXRaw;
    public float moveX;
    public PlayerControls playerControl;

    public bool jump;
    public float jumpForce;
    //public int jumpCount;
    public bool isGround;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerControl = new PlayerControls();

        playerControl.InGame.Jump.started += ctx => jump = true;
        playerControl.InGame.Jump.canceled += ctx => jump = false;
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void FixedUpdate()
    {
        moveXRaw = playerControl.InGame.Move.ReadValue<float>();
        moveX = rb.velocity.x + moveXRaw;
        rb.velocity = new Vector2(moveX,rb.velocity.y);


        if (jump && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
            jump = false;
        }

        else
        {
            isGround = true;

        }
        
    }

    public void Ground()
    {
        //Physics.Raycast(,);
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }
}
