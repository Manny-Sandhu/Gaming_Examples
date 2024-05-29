using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private UIManager ui;
    [SerializeField] private float ballSpeed = 0f;
    private int scoreP1 = 0;
    private int scoreP2 = 0;

    private Vector3 GetRandomBallDirection()
    {
        int x = -1, y = -1;

        if (Random.Range(0, 2) == 1)
        {
            x = 1;
        }
        if (Random.Range(0, 2) == 1)
        {
            y = 1;
        }

        return new Vector3(x, y, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        ball.Launch(GetRandomBallDirection(), ballSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (ball.transform.position.x > 11 || ball.transform.position.x < -11)
        {
            if (ball.transform.position.x > 11)
            {
                scoreP1++;
            }
            else
            {
                scoreP2++;
            }
            ui.UpdateScore(scoreP1, scoreP2);
            ball.Reset();
            ball.Launch(GetRandomBallDirection(), ballSpeed);
        }
    }
}
