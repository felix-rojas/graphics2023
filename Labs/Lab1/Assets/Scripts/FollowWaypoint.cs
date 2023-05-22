using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour {
    // The target marker.
    public GameObject target;

    // Angular speed in radians per sec.
    public float speed;
    public float rotationSpeed;

    void Update()
    {
        // target the wayPoint
        target = GameObject.Find("Vehiculo1");

        // Determine which direction to rotate towards
        Vector3 targetDirection = target.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float rotationSpeed = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}