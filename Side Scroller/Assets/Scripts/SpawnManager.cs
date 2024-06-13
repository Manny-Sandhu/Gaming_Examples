using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPoint;
    private float startDelay = 2;
    private float repeatRate = 2;

    List<Obstacles> obstacles;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<Obstacles> ();
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void OnDisable()
    {
        CancelInvoke();
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i] != null)
            {
                obstacles[i].enabled = false;
            }
        }
    }

    private void SpawnObstacle()
    {
        GameObject obj = Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation);
        Obstacles obstacle = obj.GetComponent<Obstacles>();
        obstacles.Add(obstacle);
    }

    public void DestroyObstacles()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i] != null)
            {
                Destroy(obstacles[i].gameObject);
            }
        }
        obstacles.Clear();
    }
}
