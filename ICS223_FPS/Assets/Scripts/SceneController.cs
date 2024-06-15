using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);

    [SerializeField] private GameObject IguanaPrefab;
    [SerializeField] private Transform iguanaSpawnPoints;
    [SerializeField] private int iguanaNum = 0;
    private GameObject[] iguanas;

    [SerializeField] private int enemyNum = 0;
    private GameObject[] enemies;

    private void Start()
    {
        enemies = new GameObject[enemyNum];
        iguanas = new GameObject[iguanaNum];

        // Randomly choose the spawn point of the iguanas
        for(int i = 0; i < iguanaNum; i++)
        {
            Vector3 point = iguanaSpawnPoints.GetChild(Random.Range(0, iguanaSpawnPoints.childCount)).position;
            iguanas[i] = Instantiate(IguanaPrefab) as GameObject;
            iguanas[i].transform.position = point;
        }
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
