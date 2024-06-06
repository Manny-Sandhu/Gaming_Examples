using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);

    [SerializeField] private int enemyNum = 0;
    private GameObject[] enemies;

    private void Start()
    {
        enemies = new GameObject[enemyNum];
    }

    // Update is called once per frame
    void Update()
    {
        // this is very inefficent ask if there is a better way 
        for(int i = 0; i < enemyNum; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
            }
        }
    }
}
