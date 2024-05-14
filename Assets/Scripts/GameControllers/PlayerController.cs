using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public JoystickController joystickController;
    public float playerSpeed;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (joystickController.joystickVector.x != 0)
        {
            rigidBody.velocity = new Vector2(joystickController.joystickVector.x * playerSpeed, 0);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }
}
