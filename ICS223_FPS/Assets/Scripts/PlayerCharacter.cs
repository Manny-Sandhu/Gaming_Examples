using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int maxHealth = 5;
    private float healthPercent;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        healthPercent = 1;
    }

    public void Hit()
    {
        health -= 1;
        healthPercent = (float)health / maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);

        /*Debug.Log("Health: " + health);
        if (health == 0)
        {
            Debug.Break();
        }*/
    }
}
