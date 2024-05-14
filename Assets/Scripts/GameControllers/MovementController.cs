using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
    public CharacterController2D playerController;
    public JoystickController joystickController;
    public float playerSpeed;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float joystickX = joystickController.joystickVector.x;
        float velocityY = rigidBody.velocity.y;

        // Handle Animations
        // spriteRenderer.flipX = joystickX < 0f;
        animator.SetFloat("Velocity", Math.Abs(joystickX));
        animator.SetFloat("VelocityY", velocityY);


        float movement = joystickX * playerSpeed * 100;

        playerController.Move(movement * Time.fixedDeltaTime, false, isJump);
        isJump = false;

    }

    public void JumpClick()
    {
        isJump = true;
    }
}
