using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float speed = 25f;
    private Vector3 startPos;
    private float halfWidth = 112.8f / 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.left * speed * Time.deltaTime;
        transform.Translate(movement);

        if(transform.position.x < startPos.x - halfWidth)
        {
            transform.position += new Vector3(halfWidth, 0, 0);
        }
    }
}
