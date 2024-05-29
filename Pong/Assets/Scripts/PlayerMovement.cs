using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private string vertInputAxis = "VertticalP1";
    [SerializeField] private float speed = 0f;
    private float vertInput;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertInput = Input.GetAxisRaw(vertInputAxis);
    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(0, vertInput * speed * Time.deltaTime, 0);
        Vector3 newPos = movement + transform.position;
        newPos.y = Mathf.Clamp(newPos.y, -4, 4);
        rb.MovePosition(newPos);
    }
}
