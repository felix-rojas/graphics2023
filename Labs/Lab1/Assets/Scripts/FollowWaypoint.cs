using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour {
    // The target marker.
    public GameObject target;

    // Angular speed in radians per sec.
    public float speed = 1.0f;

    void LateUpdate()
    {
        // target the wayPoint
        target = GameObject.Find("wayPoint");

        // Determine which direction to rotate towards
        Vector3 targetDirection = target.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}