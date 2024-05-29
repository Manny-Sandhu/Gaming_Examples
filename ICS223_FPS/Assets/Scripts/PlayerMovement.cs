using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    [SerializeField] private float speed = 0f;
    [SerializeField] Vector3 rotationVector = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        /*transform.Translate(movement);*/
        /*rb.AddForce(movement);*/
        rb.velocity = movement;

        Vector3 rotate = rotationVector * Time.deltaTime * speed * Input.GetAxis("Horizontal");
        transform.Rotate(rotate);
    }
}
