using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public static class GameObjectThrower
{
    public static void Throw(Rigidbody rb, Vector3 direction)
    {
        rb.AddForce(direction, ForceMode.Impulse);
    }

    public static void Throw(Rigidbody rb, Vector3 direction, Rigidbody source)
    {
        rb.transform.position = source.position;
        rb.velocity = source.velocity;
        Throw(rb, direction);
    }
}