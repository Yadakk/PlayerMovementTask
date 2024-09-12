using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float Lifetime = 5f;
    public float ShootForce = 10f;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameObjectLifetimeTimer lifetimeTimer = new(Lifetime);
        lifetimeTimer.StartTimer(this);

        GameObjectThrower.Throw(_rigidBody, transform.forward * ShootForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
