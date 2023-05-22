using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalObj : MonoBehaviour
{
    public Rigidbody rb;

    void FixedUpdate()
    {
        // loop through all our objects and call our Attract method
        GravitationalObj[] objs = FindObjectsOfType<GravitationalObj>();
        foreach (GravitationalObj obj in objs)
        {
            if (obj != this)
            {
                Attract(obj);
            }   
        };
    }

    // deals with the gravitational force between 2 objects
    void Attract(GravitationalObj objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        // find direction and distance of objects
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        // using newton's law to calculate the force on the object
        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
