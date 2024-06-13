using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Background background;
    [SerializeField] private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        background.enabled = false;
        spawnManager.enabled = false;
        StartCoroutine(StartAgain());
    }

    private void Reset()
    {
        spawnManager.DestroyObstacles();
        spawnManager.enabled = true;
        background.enabled = true;
        playerController.Reset();
    }

    IEnumerator StartAgain()
    {
        yield return new WaitForSeconds(3);
        Reset();
    }
}
