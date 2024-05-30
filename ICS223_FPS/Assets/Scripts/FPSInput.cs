using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField] private float speed = 9.0f;
    [SerializeField] private CharacterController charController;
    private float horizontalInput;
    private float verticalInput;
    private float gravity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        // Clamp magnitude to limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        // take speed into account
        movement *= speed;
        // add gravity
        movement.y = gravity;
        // make movement processor independent
        movement *= Time.deltaTime;
        // Convert local to global coordinates
        movement = transform.TransformDirection(movement);
        charController.Move(movement);

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed;
        transform.Translate(movement);
    }
}
