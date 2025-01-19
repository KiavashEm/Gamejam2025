using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveWithoutRotation : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoint objects
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    public Vector3 initialOffset = new Vector3(0, 0, 1); // Adjust this value to set the initial forward position

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Prevent the agent from rotating automatically

        // Set the initial position to be forward from the background
        transform.position = Vector3.zero + initialOffset;
        transform.rotation = Quaternion.identity; // Set the rotation to 0

        MoveToNextWaypoint();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextWaypoint();
        }

        // Maintain the agent's original rotation
        transform.rotation = Quaternion.identity;
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        if (currentWaypointIndex < waypoints.Length)
        {
            agent.destination = waypoints[currentWaypointIndex].position;
            currentWaypointIndex++;
        }
        else
        {
            agent.isStopped = true; // Stop the agent when it reaches the last waypoint
        }
    }
}
