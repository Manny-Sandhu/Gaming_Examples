using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 25f;
    private float xBoundry = -20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = Vector3.left * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        
        if(transform.position.x < xBoundry)
        {
            Destroy(this.gameObject);
        }
    }
}
