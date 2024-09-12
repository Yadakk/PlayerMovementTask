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

        //ClampCameraRotation(cameraTransform);
    }

    private static void ClampCameraRotation(Transform cameraTransform)
    {
        Vector3 euler = cameraTransform.eulerAngles;
        euler.y = Mathf.Clamp(cameraTransform.eulerAngles.y, -90f, 90f);
        cameraTransform.eulerAngles = euler;
    }

    public static void Jump(Rigidbody rb, float force)
    {
        rb.AddForce(Vector3.up * force);
    }
}
