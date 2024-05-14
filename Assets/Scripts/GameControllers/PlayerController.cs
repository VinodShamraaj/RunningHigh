using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public JoystickController joystickController;
    public float playerSpeed;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private Animator animator;

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

        // Handle Animations
        spriteRenderer.flipX = joystickX < 0f;
        animator.SetFloat("Velocity", Math.Abs(joystickX));



        if (joystickX != 0)
        {
            rigidBody.velocity = new Vector2(joystickX * playerSpeed, 0);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }
}
