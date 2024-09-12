using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectThrower
{
    public static void Throw(Rigidbody rb, Vector3 direction)
    {
        rb.AddForce(direction, ForceMode.Impulse);
    }
}