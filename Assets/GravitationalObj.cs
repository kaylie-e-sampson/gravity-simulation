using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalObj : MonoBehaviour
{
    public Rigidbody rb;

    public float velocityX;
    public float velocityY;

    const float G = 667.4f;

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
        Objs.Add(this);
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

        // using newton's law to calculate the force on the object
        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
