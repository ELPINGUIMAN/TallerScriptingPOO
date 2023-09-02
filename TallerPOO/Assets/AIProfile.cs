using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIProfile : MonoBehaviour
{
    public float viewDistance = 5f;

    public abstract void ExecuteProfile();

    public void OnPlayerDetected()
    {
        Debug.Log("Player found");
    }

    public bool DetectPlayer()
    {
        Vector2 aiPosition = transform.position;
        Vector2 playerPosition = FindPlayerPosition();

        float distanceToPlayer = Vector2.Distance(aiPosition, playerPosition);

        if (distanceToPlayer <= viewDistance)
        {
            return true;
        }

        return false;
    }

    protected abstract Vector2 FindPlayerPosition();
}
