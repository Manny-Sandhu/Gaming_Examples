using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private WaypointPath path;          // the path we are following
    [SerializeField] 
    private float seconds;              

    private Transform sourceWP;         // the waypoint transform we are travelling from
    private Transform targetWP;         // the waypoint transform we are travelling to
    private int targetWPIndex = 0;      // the waypoint index we are travelling to

    private float totalTimeToWP;        // the total time to get from source WP to targetWP
    private float elapsedTimeToWP = 0;  // the elapsed time (sourceWP to targetWP)
    private float speed = 3.0f;         // movement speed
    private bool isPaused = false;

     void Start()
    {
        TargetNextWaypoint();
    }

    void FixedUpdate()
    {
        StartCoroutine(StopPlatform(seconds));
    }


    // Determine what waypoint we are going to next, and set associated variables
    private void TargetNextWaypoint()
    {
        // reset the elapsed time
        elapsedTimeToWP = 0;

        // determine the source waypoint
        sourceWP = path.GetWaypoint(targetWPIndex);

        // determine the target waypoint
        targetWPIndex++;

        // if we exhausted our waypoints, go the to first waypoint
        if(targetWPIndex >= path.GetWaypointCount())
        {
            targetWPIndex = 0;
        }

        // calculate source to target distance
        targetWP = path.GetWaypoint(targetWPIndex);

        //caculate the distance to the WP
        float distanceToWp = Vector3.Distance(sourceWP.position, targetWP.position);

        // calculate time to waypoint
        totalTimeToWP = distanceToWp / speed;
    }

    // Travel towards the target waypoint (call this from FixedUpdate())
    private void MoveTowardsWaypoint()
    {
        // calculate the elapsed time spent on the way to this waypoint
        elapsedTimeToWP += Time.deltaTime;

        // calculate percent complete
        float elapsedTimePercentage = elapsedTimeToWP / totalTimeToWP;

        // make speed slower at the begining and end 
        elapsedTimePercentage = Mathf.SmoothStep(0, 1, elapsedTimePercentage);
        // move
        transform.position = Vector3.Lerp(sourceWP.position, targetWP.position, elapsedTimePercentage);
        // rotate
        transform.rotation = Quaternion.Lerp(sourceWP.rotation, targetWP.rotation, elapsedTimePercentage);
        // check if we've reached our waypoint (based on time). If so, target the next waypoint
        if(elapsedTimePercentage >= 1)
        {
            isPaused = true;
            TargetNextWaypoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

    private IEnumerator StopPlatform(float seconds)
    {
        if (isPaused)
        {
            yield return new WaitForSeconds(seconds);
            isPaused = false;
        }
        MoveTowardsWaypoint();
    }
}
