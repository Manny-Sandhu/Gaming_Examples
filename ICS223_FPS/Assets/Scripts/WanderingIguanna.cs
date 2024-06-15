using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingIguanna : MonoBehaviour
{
    private float iguanaSpeed = 3.0f;
    private float obstacleRange = 4.0f;
    private Animator anim;
    private float turn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = iguanaSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Determine if were headed for an obstacle (so we can decide if we need to turn)
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // test for a collision 
        if (Physics.SphereCast(ray, 0.5f, out hit))
        {
            if(hit.distance < obstacleRange)
            {
                // if oir turn value is not set (0) we need to decide on a left or right turn
                if (Mathf.Approximately(turn, 0.0f))
                {
                    // Flip a coin (0 or 1), 0 means a left turn, 1 means right
                    turn = Random.Range(0, 2) == 0 ? -0.75f : 0.75f;
                }

                // blending will caise the Iguana to move forward and turn at the same time
                // turn quickly move forward slowly
                Move(turn, 0.1f);
            }
            else    // n obstacle, ok, to move foward without turning
            {
                float forwardSpeed = Random.Range(0.05f, 1.0f);
                turn = 0.0f;    // set the turn value to 0

                // no blending happens here since we are not turning
                Move(turn, forwardSpeed);
            }
        }
    }

    private void Move(float turn, float forward)
    {
        float dampTime = 0.2f;
        if (anim != null)
        {
            anim.SetFloat("Turn", turn, dampTime, Time.deltaTime);
            anim.SetFloat("Forward", forward, dampTime, Time.deltaTime);
        }
    }
}
