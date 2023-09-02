using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPingPong : AIProfile
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isMovingForward = true;

    public override void ExecuteProfile()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("La lista de puntos de patrulla está vacía.");
            return;
        }

        Vector2 targetPosition = waypoints[currentWaypointIndex].position;

        transform.position = targetPosition;

        if (isMovingForward)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = waypoints.Length - 2;
                isMovingForward = false;
            }
        }
        else
        {
            currentWaypointIndex--;
            if (currentWaypointIndex < 0)
            {
                currentWaypointIndex = 1;
                isMovingForward = true;
            }
        }
    }

    protected override Vector2 FindPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return player.transform.position;
        }

        return Vector2.zero;
    }
}
