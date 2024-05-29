using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb = null;

    public void Launch(Vector3 movement, float speed)
    {
        rb.AddForce(movement * speed, ForceMode.Impulse);
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(0,0,0);
    }

    // Start is called before the first frame update
    void Start()
    {
   
    }
}
