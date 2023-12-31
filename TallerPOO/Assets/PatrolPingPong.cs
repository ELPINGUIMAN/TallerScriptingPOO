using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPingPong : AIProfile
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isMovingForward = true;
    public float moveSpeed = 2.0f;

    private void Update()
    {
        ExecuteProfile();
        if (DetectPlayer() == true)
        {
            OnPlayerDetected();
        }
    }

    public override void ExecuteProfile()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("La lista de puntos de patrulla est� vac�a.");
            return;
        }

        Vector2 targetPosition = waypoints[currentWaypointIndex].position;

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
        if (distanceToTarget <= 0.1f)
        {
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                isMovingForward = false;
            }
            else if (currentWaypointIndex == 0)
            {
                isMovingForward = true;
            }

            if (isMovingForward)
            {
                currentWaypointIndex++;
            }
            else
            {
                currentWaypointIndex--;
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
