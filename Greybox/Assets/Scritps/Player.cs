using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class Player : MonoBehaviour
{
    // the speed of the player
    [SerializeField] private float speed = 6.0f;
    // the character controller for the player 
    [SerializeField] CharacterController cc;

    // mouse movement X
    private float deltaHoriz;
    // keyboard movement x
    private float horizontalInput;
    // keyboard movement z
    private float verticalInput;
    // player movement vector
    private Vector3 movement;
    
    // enum for choosing what mouse controls should be used 
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }

    // public class-scope variable so it shows up in Inspector
    public RotationAxes axes = RotationAxes.MouseXAndY;
    // mouse movement options
    public float sensitivityHoriz = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    // gravity variables
    private float gravity = -9.81f;
    private float yVelocity = 0f;
    private float yVelocityWhenGrounded = -4.0f;

    // jump variables 
    [SerializeField] private float jumpHeight = 3.0f;
    [SerializeField] private float jumpTime = 0.5f;
    private float initialJumpVelocity = 0f;
    // amount of jumps the player is currently allowed
    [SerializeField] private int jumps = 2;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HandleJump();
    }

    // handle how high the jump will be only called once in the start function
    public void HandleJump()
    {
        float timeToApex = jumpTime / 2.0f;
        gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * jumpHeight) / timeToApex;
    }

    // Update is called once per frame
    void Update()
    {
        // player inputs
        deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // set movement 
        movement = new Vector3(horizontalInput, 0, verticalInput);
        // makes sure diagonal movement doesnt exceed horiz/vert movement speed
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        // convert from local to world coordinates
        movement = transform.TransformDirection(movement);
        // add speed to movement
        movement *= speed;
        // add gravity if needed
        yVelocity += gravity * Time.deltaTime;

        // if the player is grounded set jumps to 2 and set yVelocity to grounded
        if (cc.isGrounded)
        {
            jumps = 2;

            if (yVelocity < 0.0)
            {
                yVelocity = yVelocityWhenGrounded;
            }
        }

        // on jump change yVelocity and remove a jump counter
        if(Input.GetButtonDown("Jump") && jumps > 0)
        {
            yVelocity = initialJumpVelocity;
            jumps--;
        }

        // add vertical velocity
        movement.y = yVelocity;
        movement *= Time.deltaTime;

        // move the player
        cc.Move(movement);

        // camera rotation
        Vector3 rotate = new Vector3(0, deltaHoriz, 0) * 180 * Time.deltaTime;
        transform.Rotate(rotate);
    }

    // Respawn the player at a set position
    public void Respawn(Vector3 spawnPoint)
    {
        // stop falling
        yVelocity = yVelocityWhenGrounded;
        // set the player to a given position
        transform.position = spawnPoint;
        // apply transform changes to the physics engine manually
        Physics.SyncTransforms();
    }
}
