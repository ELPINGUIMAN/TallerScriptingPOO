using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCyclic : AIProfile
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public override void ExecuteProfile()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("La lista de puntos de patrulla está vacía.");
            return;
        }

        Vector2 targetPosition = waypoints[currentWaypointIndex].position;

        transform.position = targetPosition;

        currentWaypointIndex++;

        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
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
