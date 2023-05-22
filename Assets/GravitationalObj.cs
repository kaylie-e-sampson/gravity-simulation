using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalObj : MonoBehaviour
{
    public Rigidbody rb;
    public float velocityX;
    public float velocityY;

    const float G = 6.67430f;

    // scales for distances and velocities
    float scaleDistance = 3.85f;   // Adjusted scale for distance
    float scaleVelocity = 0.0108f;  // Adjusted scale for velocity

    // list of all objects in the scene
    public static List<GravitationalObj> Objs;

    void FixedUpdate()
    {
        Time.fixedDeltaTime = 0.001f;
        // loop through all our objects and call our Attract method
        foreach (GravitationalObj obj in Objs)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }

    void OnEnable()
    {
        if (Objs == null)
        {
            Objs = new List<GravitationalObj>();
        }
        Objs.Add(this); // Add the Moon object to the end of the list

        // Adjust the initial position of the Moon slightly
        rb.position += new Vector3(0f, 0.01f, 0f); // Move the Moon slightly above the Earth's plane
    }

    void OnDisable()
    {
        Objs.Remove(this);
    }

    // deals with the gravitational force between 2 objects
    void Attract(GravitationalObj objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        // Find direction and distance of objects
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        // If objects are in the exact same position, return
        if (distance == 0f)
        {
            return;
        }

        // Scale the distance and direction
        float scaledDistance = distance / scaleDistance;
        Vector3 scaledDirection = direction.normalized;

        // Calculate the force magnitude
        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(scaledDistance, 2);
        Vector3 force = scaledDirection * forceMagnitude;

        rbToAttract.AddForce(force);

        // Calculate the velocity required for orbital motion
        Vector3 velocity = new Vector3(velocityX, velocityY, 0f);
        velocity *= scaleVelocity;

        // Adjust the velocity based on the orbital motion
        Vector3 relativePosition = rbToAttract.position - rb.position;
        Vector3 relativeVelocity = rbToAttract.velocity - rb.velocity;
        float orbitalSpeed = Mathf.Sqrt(G * rb.mass / distance); // Calculate orbital speed

        // Get the tangential velocity direction perpendicular to the relative position
        Vector3 tangent = new Vector3(-relativePosition.y, relativePosition.x, 0f).normalized;

        // Set the final velocity
        velocity += tangent * orbitalSpeed;
        rbToAttract.velocity = velocity;
    }
}
