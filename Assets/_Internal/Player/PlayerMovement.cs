using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovement
{
    public static void Move(Rigidbody rb, Vector2 direction)
    {
        Vector3 rotatedDirection = rb.transform.rotation * new Vector3(direction.x, 0f, direction.y);
        rb.AddForce(rotatedDirection, ForceMode.Impulse);
    }

    public static void Rotate(Transform playerTransform, Vector2 delta)
    {
        playerTransform.Rotate(new(0f, delta.x, 0f));

        Transform cameraTransform = Camera.main.transform;
        cameraTransform.RotateAround(playerTransform.position, playerTransform.right, delta.y);
        if (cameraTransform.rotation.eulerAngles.z > 90f) //Is camera upside down
        {
            if (delta.y > 0)
                cameraTransform.RotateAround(playerTransform.position, playerTransform.right, cameraTransform.rotation.eulerAngles.x - 90f);
            else
                cameraTransform.RotateAround(playerTransform.position, playerTransform.right, cameraTransform.rotation.eulerAngles.x - 270f);
        }
    }

    public static void Jump(Rigidbody rb, float force)
    {
        rb.AddForce(Vector3.up * force);
    }
}
