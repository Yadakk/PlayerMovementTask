using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Lifetime = 5f;

    private void Start()
    {
        GameObjectLifetimeTimer lifetimeTimer = new(Lifetime);
        lifetimeTimer.StartTimer(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
