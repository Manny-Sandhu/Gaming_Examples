using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -5)
        {
            player.Respawn(startPosition);
        }
    }
}
