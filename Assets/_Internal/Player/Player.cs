using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Jump")]
    public float JumpForce = 10f;

    [Header("Throw")]
    public GameObject Throwable;
    public Transform ThrowableParent;
    public float ThrowForce = 10f;

    public bool IsGrounded { get; private set; }

    private Rigidbody _rigidBody;
    public Rigidbody RigidBody { get => _rigidBody; }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
