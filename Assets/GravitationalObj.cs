using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalObj : MonoBehaviour
{
    public Rigidbody rb;

    const float G = 667.4f;

    // scales for distances and velocities
    public float scaleDistance = 1000f;
    public float scaleVelocity = 0.1f;

    // list of all objects in the scene
    public static List<GravitationalObj> Objs;

    void FixedUpdate()
    {
        // loop through all our objects and call our Attract method
        foreach (GravitationalObj obj in Objs)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        };
    }

    void OnEnable()
    {
        if (Objs == null)
        {
            Objs = new List<GravitationalObj>();
        }
        Objs.Insert(0, this); // Insert the moon object at the beginning of the list
    }

    void OnDisable()
    {
        Objs.Remove(this);
    }

    // deals with the gravitational force between 2 objects
    void Attract(GravitationalObj objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        // find direction and distance of objects
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        // if objects are in the exact same position, return
        if (distance == 0f)
        {
            return;
        }

        // scale the distance and velocity
        float scaledDistance = distance / scaleDistance;
        Vector3 scaledDirection = direction.normalized * scaledDistance;

        // Using Newton's law to calculate the force on the object
        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(scaledDistance, 2);
        Vector3 force = scaledDirection.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

        // Calculate the velocity required for orbital motion
        Vector3 velocity = new Vector3(0f, 0f, 0f); // Earth's velocity remains 0
        if (gameObject.name == "Moon")
        {
            velocity.x = 0.1008f * scaleVelocity; // Set the Moon's scaled velocity
            velocity.y = 0.1008f * scaleVelocity;
        }
        velocity += force / rbToAttract.mass * Time.fixedDeltaTime;
        rbToAttract.velocity = velocity;
    }
}
