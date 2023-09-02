using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : AIProfile
{
    private float nextTurnTime;

    private void Update()
    {
        if (Time.time >= nextTurnTime)
        {
            ExecuteProfile();
        }
        if (DetectPlayer() == true)
        {
            OnPlayerDetected();
        }
    }

    public override void ExecuteProfile()
    {
        if (Time.time >= nextTurnTime)
        {
            float randomAngle = Random.Range(0f, 360f);

            transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);

            nextTurnTime = Time.time + waitForTurn;
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
