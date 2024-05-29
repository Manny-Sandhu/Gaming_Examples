using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField] private float speed = 9.0f;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed;
        transform.Translate(movement);
    }
}
