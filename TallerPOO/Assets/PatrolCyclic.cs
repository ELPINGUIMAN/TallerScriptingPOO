using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCyclic : AIProfile
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private Vector2 currentTarget;
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
            Debug.LogWarning("La lista de puntos de patrulla está vacía.");
            return;
        }

        Vector2 targetPosition = waypoints[currentWaypointIndex].position;

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
        if (distanceToTarget <= 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
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
