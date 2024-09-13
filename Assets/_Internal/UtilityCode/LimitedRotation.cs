using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedRotation
{
    private float _currentAngle;

    public void Rotate(
        Transform target, 
        Vector3 axis, 
        float delta, float min, float max)
    {
        _currentAngle = Mathf.Clamp(_currentAngle + delta, min, max);
        target.localRotation = Quaternion.AngleAxis(_currentAngle, axis);
    }

    public void RotateAround(
        Transform target, 
        Vector3 axis, Vector3 point, 
        float delta, float min, float max)
    {
        Rotate(target, axis, delta, min, max);

        float distance = Vector3.Distance(point, target.position);
        target.position = point - (target.forward * distance);
    }
}
