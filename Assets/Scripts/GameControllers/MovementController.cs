using System;
using UnityEngine;


public class MovementController : MonoBehaviour
{
    [SerializeField]
    private CharacterController2D playerController;

    [SerializeField]
    private JoystickController joystickController;

    [SerializeField]
    private GameObject helmetObject;

    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private float playerSpeedKeyboard;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private Rigidbody2D helmetRigidBody;

    private bool doJump = false;
    private bool isJump = false;
    private float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (helmetObject != null)
        {
            helmetRigidBody = helmetObject.GetComponent<Rigidbody2D>();
        }

    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * playerSpeedKeyboard * 100;
        float velocityY = rigidBody.velocity.y;

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJump", true);
            isJump = true;
            doJump = true;
        }

        if (isJump && velocityY < -0.1f)
        {
            animator.SetBool("IsJump", false);
            isJump = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float joystickX = joystickController.joystickVector.x;
        float velocityY = rigidBody.velocity.y;
        float velocity = Math.Abs(joystickX);
        float velocityKeyboard = Math.Abs(horizontalMove);

        // Handle Animations
        animator.SetFloat("Velocity", velocity);
        animator.SetFloat("VelocityY", velocityY);

        float movement = joystickX * playerSpeed * 100;

        if (movement != 0)
        {
            animator.SetFloat("Velocity", velocity);
            playerController.Move(movement * Time.fixedDeltaTime, false, doJump);
        }
        else
        {
            animator.SetFloat("Velocity", velocityKeyboard);
            playerController.Move(horizontalMove * Time.fixedDeltaTime, false, doJump);
        }
        doJump = false;


    }

    public void JumpClick()
    {
        isJump = true;
        doJump = true;
        animator.SetBool("IsJump", true);
    }
}
